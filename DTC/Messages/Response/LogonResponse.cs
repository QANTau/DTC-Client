using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Logon Response Message
        /// </summary>
        public class LogonResponse : JsonHeader
        {
            #region C++ Struct
            //char Reason[TEXT_DESCRIPTION_LENGTH];
            //uint8_t DoNotReconnect;
            #endregion
            
            public int ProtocolVersion { get; set; }
            public Protocol.LogonStatus Result { get; set; }
            public string ResultText { get; set; }
            public string ReconnectAddress { get; set; }
            public int Integer_1 { get; set; }
            public string ServerName { get; set; }
            public byte MarketDepthUpdatesBestBidAndAsk { get; set; }
            public byte TradingIsSupported { get; set; }
            public byte OcoOrdersSupported { get; set; }
            public byte OrderCancelReplaceSupported { get; set; }
            public string SymbolExchangeDelimiter { get; set; }
            public byte SecurityDefinitionsSupported { get; set; }
            public byte HistoricalPriceDataSupported { get; set; }
            public byte ResubscribeWhenMarketDataFeedAvailable { get; set; }
            public byte MarketDepthIsSupported { get; set; }
            public byte OneHistoricalPriceDataRequestPerConnection { get; set; }
            public byte BracketOrdersSupported { get; set; }
            public byte UseIntegerPriceOrderMessages { get; set; }
            public byte UsesMultiplePositionsPerSymbolAndTradeAccount { get; set; }
            public byte MarketDataSupported { get; set; }

        }
    }
}
