using System;

namespace QANT.DTC
{
    public partial class Client
    {
        public class MessageEventArgs : EventArgs
        {
            private readonly Messages.Header _header;

            private readonly object _msg;

            public MessageEventArgs(Messages.Header header, object msg)
            {
                _header = header;
                _msg = msg;
            }

            public ushort Size => _header.Size;

            public Protocol.MessageType Type => _header.Type;

            public object Msg => _msg;
        }
    }
}