using System;

namespace QANT.DTC
{
    public partial class Client
    {
        public class ErrorEventArgs : EventArgs
        {
            private string _msg;

            public Exception Exception { get; set; }

            public string Msg { get => _msg; set => _msg = value; }

            public ErrorEventArgs(Exception ex, string msg)
            {
                Exception = ex;
                Msg = msg;
            }
        }
    }
}