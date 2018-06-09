using System;

namespace QANT.DTC
{
    public partial class Client
    {
        public class ErrorEventArgs : EventArgs
        {
            public Exception Exception { get; set; }

            public string Message { get; set; }

            public ErrorEventArgs(Exception ex, string message)
            {
                Exception = ex;
                Message = message;
            }
        }
    }
}