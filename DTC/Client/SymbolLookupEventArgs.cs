using System;

namespace QANT.DTC
{
    public partial class Client
    {
        public class SymbolLookupEventArgs : EventArgs
        {
            public Messages.SecurityDefinitionResponse LookupResult { get; set; }

            public SymbolLookupEventArgs(Messages.SecurityDefinitionResponse lookupResult)
            {
                LookupResult = lookupResult;
            }
        }
    }
}