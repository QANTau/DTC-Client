using System;

namespace QANT.DTC
{
    public partial class Client
    {
        public class MessageEventArgs : EventArgs
        {
            public string Message { get; }

            public MessageEventArgs(string message)
            {
                Message = message;
            }
        }
    }
}