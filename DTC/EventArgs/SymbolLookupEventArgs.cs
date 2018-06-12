using System;

namespace QANT.DTC
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