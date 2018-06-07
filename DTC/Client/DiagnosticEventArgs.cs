using System;

namespace QANT.DTC
{
    public partial class Client
    {
        public class DiagnosticEventArgs : EventArgs
        {
            private string _msg;

            public string Msg { get => _msg; set => _msg = value; }

            public DiagnosticEventArgs(string msg)
            {
                Msg = msg;
            }
        }
    }
}