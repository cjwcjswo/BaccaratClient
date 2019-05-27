using System;
using System.Collections.Generic;

namespace Protocol
{
    public static class Packet
    {
        private const int PACKET_ID_INDEX = 0;
        private const int PACKET_TOTAL_SIZE_INDEX = 2;
        private const int PACKET_RESULT_INDEX = 4;
        public const short PACKET_HEADER_SIZE = 6;
        
        public static byte[] EncodingPacket(short packetId, short result, byte[] packetBody)
        {
            var totalSize = (short)(PACKET_HEADER_SIZE + packetBody.Length);
            var sendBuffer = new List<byte>();
            sendBuffer.AddRange(BitConverter.GetBytes(packetId));
            sendBuffer.AddRange(BitConverter.GetBytes(totalSize));
            sendBuffer.AddRange(BitConverter.GetBytes(result));
            sendBuffer.AddRange(packetBody);
            return sendBuffer.ToArray();
        }

        public static short PacketId(byte[] data)
        {
            return BitConverter.ToInt16(data, PACKET_ID_INDEX);
        }
        
        public static short PacketTotalSize(byte[] data)
        {
            return BitConverter.ToInt16(data, PACKET_TOTAL_SIZE_INDEX);
        }
        
        public static short PacketResult(byte[] data)
        {
            return BitConverter.ToInt16(data, PACKET_RESULT_INDEX);
        }

        public static byte[] PacketBody(byte[] data)
        {
            var totalSize = PacketTotalSize(data);
            var result = new byte[totalSize - PACKET_HEADER_SIZE];
            Buffer.BlockCopy(data, PACKET_HEADER_SIZE, result, 0, totalSize - PACKET_HEADER_SIZE);
            return result;
        }
    }
}