
namespace QANT.DTC
{
    /// <summary>
    /// DTC Protocol
    /// </summary>
    public partial class Protocol
    {
        // General Purpose Constants
        public const string ProtocolType = "DTC";
        public const int CurrentVersion = 8;
        public const int HeartbeatInterval = 15;                // Seconds
        public const int HeartbeatLossMaximum = 4;              // Max. Allowed Heartbeat Send/Receive Diff.

        public const int BufferSize = 8192;                     // DTC Socket Receive Buffer Size (8K)
        public const int HistoricalBufferSize = 134217728;      // DTC Historical Socket Receive Buffer Size (128 MB)

        // Text string lengths. 
        public const int UsernamePasswordLength = 32;
        public const int SymbolExchangeDelimiterLength = 4;
        public const int SymbolLength = 64;
        public const int ExchangeLength = 16;
        public const int UnderlyingSymbolLength = 32;
        public const int SymbolDescriptionLength = 64;//Previously 48
        public const int ExchangeDescriptionLength = 48;
        public const int OrderIdLength = 32;
        public const int TradeAccountLength = 32;
        public const int TextDescriptionLength = 96;
        public const int TextMessageLength = 256;
        public const int OrderFreeFormTextLength = 48;
        public const int ClientNameLength = 32;
        public const int ClientServerNameLength = 48;
        public const int GeneralIdentifierLength = 64;
        public const int ReconnectAddressLength = 64;
        public const int ServerNameLength = 60;
    }
}
