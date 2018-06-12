using System;

namespace QANT.DTC
{
    public class RawMessageEventArgs : EventArgs
    {
        public byte[] Packet { get; }

        public Protocol.MessageType MessageType { get; }

        public RawMessageEventArgs(byte[] packet, Protocol.MessageType messageType)
        {
            Packet = packet;
            MessageType = messageType;
        }
    }
}