using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Google.Protobuf;
using Protocol;

namespace BaccaratClient
{
    public delegate void ShowBox(string message);
    public delegate void DisconnectEvent();
    public delegate void PacketProcess(byte[] data);
    public partial class BcApp : Form
    {
        private readonly PacketEvent _packetEvent;
        private readonly Dictionary<short, PacketEvent.PacketEventProcess> _eventDic;
        public NetworkClient Client;
        
        public BcApp()
        {
            InitializeComponent();
            _packetEvent = new PacketEvent(this);
            _eventDic = new Dictionary<short, PacketEvent.PacketEventProcess>
            {
                [PacketId.PACKET_ID_LOGIN_RES] = _packetEvent.LoginEvent,
                [PacketId.PACKET_ID_ENTER_ROOM_RES] = _packetEvent.RoomEnterEvent,
                [PacketId.PACKET_ID_ROOM_NEW_USER_BROADCAST] = _packetEvent.RoomNewUserInfoEvent,
                [PacketId.PACKET_ID_ROOM_USER_LIST_NOTIFY] = _packetEvent.RoomUserInfoListEvent,
                [PacketId.PACKET_ID_ROOM_CHAT_RES] = _packetEvent.RoomChatResponseEvent,
                [PacketId.PACKET_ID_ROOM_CHAT_BROADCAST] = _packetEvent.RoomChatBroadcastEvent,
                [PacketId.PACKET_ID_ROOM_LEAVE_BROADCAST] = _packetEvent.RoomLeaveBroadcastEvent,
                [PacketId.PACKET_ID_GAME_BETTING_RES] = _packetEvent.GameResponseEvent,
                [PacketId.PACKET_ID_GAME_BETTING_BROADCAST] = _packetEvent.GameBettingBroadcastEvent,
                [PacketId.PACKET_ID_GAME_ROUND_BROADCAST] = _packetEvent.GameRoundEvent,
                [PacketId.PACKET_ID_GAME_RESULT_BROADCAST] = _packetEvent.GameResultEvent,
                [PacketId.PACKET_ID_GAME_BETTING_START_BROADCAST] = _packetEvent.GameBettingStartBroadcastEvent,
            };
        }
        
        private static void ShowBoxMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void DisconnectEvent()
        {
            if (Client == null)
            {
                return;
            }
            Client.Disconnect();

            nicknameTextBox.Enabled = false;
            roomNumTextBox.Enabled = false;
            enterButton.Enabled = false;
            loginButton.Enabled = false;
            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
            hostTextBox.Enabled = true;
            Client = null;
        }

        private void PacketProcess(byte[] data)
        {
            var packetId = Packet.PacketId(data);
            if (!_eventDic.ContainsKey(packetId))
            {
                return;
            }

            _eventDic[packetId](Packet.PacketResult(data), Packet.PacketBody(data));
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                var hostName = hostTextBox.Text;
                if(hostName.Trim() == "")
                {
                    MessageBox.Show("호스트를 입력해주세요");
                    return;
                }

                var hostSplit = hostName.Split(':');
                if (hostSplit.Length != 2)
                {
                    MessageBox.Show("<IP>:<PORT> 형식으로 입력하세요");
                    return;
                }

                ShowBox showBox = ShowBoxMessage;
                var portNum = int.Parse(hostSplit[1]);
            
                Client = new NetworkClient(hostSplit[0], portNum);
                Client.SetDelegate(showBox, DisconnectEvent, PacketProcess);
            
                if (!Client.Connect()) return;
                hostTextBox.Enabled = false;
                connectButton.Enabled = false;
                nicknameTextBox.Enabled = true;
                loginButton.Enabled = true;
                disconnectButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        
        private void disconnectButton_Click(object sender, EventArgs e)
        { 
            DisconnectEvent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (Client == null)
            {
                ShowBoxMessage("먼저 서버에 접속하세요");
                return;
            }

            var nickname = nicknameTextBox.Text;
            if (nickname.Trim() == "")
            {
                ShowBoxMessage("닉네임을 입력해주세요");
                return;
            }

            User.MyInfo.TempNickname = nickname;
            var request = new LoginRequest
            {
                Nickname = nickname 
            };

            var requestBytes = request.ToByteArray();
            var loginRequest = Packet.EncodingPacket(PacketId.PACKET_ID_LOGIN_REQ, Error.ERROR_CODE_NONE, requestBytes);
            Client.Send(loginRequest);
        }

        public void EventLoginUiSuccess()
        {
            nicknameTextBox.Enabled = false;
            loginButton.Enabled = false;
            roomNumTextBox.Enabled = true;
            enterButton.Enabled = true;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client == null)
                {
                    ShowBoxMessage("먼저 서버에 접속하세요");
                    return;
                }

                var roomNumText = roomNumTextBox.Text;
                if (roomNumText.Trim() == "")
                {
                    ShowBoxMessage("방 번호를 입력해주세요");
                    return;
                }

                var roomNum = int.Parse(roomNumText);
                var request = new RoomEnterRequest
                {
                    RoomNum = roomNum
                };

                var requestBytes = request.ToByteArray();
                var enterRequest = Packet.EncodingPacket(PacketId.PACKET_ID_ENTER_ROOM_REQ, Error.ERROR_CODE_NONE, requestBytes);
                Client.Send(enterRequest);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}