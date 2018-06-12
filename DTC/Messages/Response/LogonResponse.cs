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
            //LogonStatusEnum Result;
            //char ResultText[TEXT_DESCRIPTION_LENGTH];
            //char ReconnectAddress[64];
            //int32_t Integer_1;
            //char ServerName[60];
            //uint8_t MarketDepthUpdatesBestBidAndAsk;
            //uint8_t TradingIsSupported;
            //uint8_t OCOOrdersSupported;
            //uint8_t OrderCancelReplaceSupported;
            //char SymbolExchangeDelimiter[SYMBOL_EXCHANGE_DELIMITER_LENGTH];
            //uint8_t SecurityDefinitionsSupported;
            //uint8_t HistoricalPriceDataSupported;
            //uint8_t ResubscribeWhenMarketDataFeedAvailable;
            //uint8_t MarketDepthIsSupported;
            //uint8_t OneHistoricalPriceDataRequestPerConnection;
            //uint8_t BracketOrdersSupported;
            //uint8_t UseIntegerPriceOrderMessages;
            //uint8_t UsesMultiplePositionsPerSymbolAndTradeAccount;
            //uint8_t MarketDataSupported;
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
