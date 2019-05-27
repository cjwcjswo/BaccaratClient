using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Protocol;

namespace BaccaratClient
{
    public class NetworkClient
    {
        private const int MAX_BUFFER_SIZE = 1024;
        
        // ManualResetEvent instances signal completion.  
        private readonly ManualResetEvent _connectDone = new ManualResetEvent(false);
        private readonly ManualResetEvent _sendDone = new ManualResetEvent(false);

        private static bool _isConnected;
        
        private readonly byte[] _receiveBuffer;
        private int _currentBufferPos = 0;
        private Socket _client;
        private readonly string _address;
        private readonly int _portNum;
        private static ShowBox _showBox;
        private DisconnectEvent _disconnectEvent;
        private PacketProcess _packetProcess;

        public NetworkClient(string address, int portNum)
        {
            _receiveBuffer = new byte[MAX_BUFFER_SIZE];
            _address = address;
            _portNum = portNum;
            _isConnected = false;
        }

        public void SetDelegate(ShowBox showBox, DisconnectEvent disconnectEvent, PacketProcess processEvent)
        {
            _showBox = showBox;
            _disconnectEvent = disconnectEvent;
            _packetProcess = processEvent;
        }
        
        public bool Connect()
        {
            try
            {
                var ipAddress = IPAddress.Parse(_address);
                var point = new IPEndPoint(ipAddress, _portNum);
            
                _client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _client.BeginConnect(point, ConnectCallback, _client);
                _connectDone.WaitOne();
                if (!_isConnected)
                {
                    return false;
                }
                Receive();
            }
            catch (Exception e)
            {
                _showBox(e.ToString());
                return false;
            }

            return true;
        }

        public void Disconnect()
        {
            _isConnected = false;
            _client.Shutdown(SocketShutdown.Both);
            _client.Close();
        }
        
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                var arClient = (Socket) ar.AsyncState;
                arClient.EndConnect(ar);
                _isConnected = true;
            }
            catch (Exception e)
            {
                _isConnected = false;
                _showBox(e.ToString());
            }
            _connectDone.Set();
        }

        public void Send(byte[] data)
        {
            _client.BeginSend(data, 0, data.Length, 0, SendCallBack, _client);
            _sendDone.WaitOne();
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                var asClient = (Socket)ar.AsyncState;
                asClient.EndSend(ar);
                _sendDone.Set();
            }
            catch (Exception e)
            {
                _showBox(e.ToString());
            }
        }

        private void Receive()
        {
            try
            {
                _client.BeginReceive(_receiveBuffer, _currentBufferPos, MAX_BUFFER_SIZE, 0, ReceiveCallback, _client);
            }
            catch (Exception e)
            {
                _showBox(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                var arSocket = (Socket)ar.AsyncState;
                if (!_isConnected)
                {
                    return;
                }
                var readBytes = arSocket.EndReceive(ar);

                if (readBytes <= 0)
                {
                    _showBox("서버와의 연결이 끊어졌습니다.");
                    _disconnectEvent();
                    return;
                }

//                if (readBytes < Packet.PACKET_HEADER_SIZE)
//                {
//                    _showBox("메세지 수신 오류! - 헤더사이즈 불량");
//                    _disconnectEvent();
//                    return;
//                }
                
                var readAbleBytes = _currentBufferPos + readBytes;
                while (true)
                {
                    if (readAbleBytes < Packet.PACKET_HEADER_SIZE)
                    {
                        _currentBufferPos += readAbleBytes;
                        break;
                    }

                    var tempBuffer = new byte[MAX_BUFFER_SIZE - _currentBufferPos];
                    Buffer.BlockCopy(_receiveBuffer, _currentBufferPos, tempBuffer, 0, MAX_BUFFER_SIZE - _currentBufferPos);
                    
                    var totalSize = Packet.PacketTotalSize(tempBuffer);
                    if (totalSize > readAbleBytes)
                    {
                        _currentBufferPos += readAbleBytes;
                        break;
                    }

                    var packetBuffer = new byte[totalSize];
                    Buffer.BlockCopy(tempBuffer, 0, packetBuffer, 0, totalSize);
                    _packetProcess(packetBuffer);
                    
                    _currentBufferPos += totalSize;
                    readAbleBytes -= totalSize;
                }

                if (readAbleBytes > 0)
                {
                    Buffer.BlockCopy(_receiveBuffer, _currentBufferPos, _receiveBuffer, 0, readAbleBytes);
                }
                _currentBufferPos = readAbleBytes;
                Receive();
            }
            catch (Exception e)
            {
                _showBox(e.ToString());
            }
        }
    }
}