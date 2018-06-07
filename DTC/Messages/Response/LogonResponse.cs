using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Logon Response Msg
        /// </summary>
        public class LogonResponse : Header
        {
            #region C++ Struct
            //char Reason[TEXT_DESCRIPTION_LENGTH];
            //uint8_t DoNotReconnect;
            #endregion
            
            public int ProtocolVersion { get; }                                //  4 Bytes - Pos 0
            public Protocol.LogonStatus Result { get; }                        //  4 Bytes - Pos 4
            public string ResultText { get; }                                  // 96 Bytes - Pos 8
            public string ReconnectAddress { get; }                            // 64 Bytes - Pos 104
            public int Integer1 { get;  }                                      //  4 Bytes - Pos 168
            public string ServerName { get; }                                  // 60 Bytes - Pos 172 
            public byte MarketDepthUpdatesBestBidAndAsk { get; }               //  1 Byte  - Pos 232
            public byte TradingIsSupported { get; }                            //  1 Byte  - Pos 233
            public byte OcoOrdersSupported { get; }                            //  1 Byte  - Pos 234
            public byte OrderCancelReplaceSupported { get; }                   //  1 Byte  - Pos 235
            public string SymbolExchangeDelimiter { get; }                     //  4 Bytes - Pos 236
            public byte SecurityDefinitionsSupported { get; }                  //  1 Byte  - Pos 240
            public byte HistoricalPriceDataSupported { get; }                  //  1 Byte  - Pos 241
            public byte ResubscribeWhenMarketDataFeedAvailable { get; }        //  1 Byte  - Pos 242
            public byte MarketDepthIsSupported { get; }                        //  1 Byte  - Pos 243
            public byte OneHistoricalPriceDataRequestPerConnection { get; }    //  1 Byte  - Pos 244
            public byte BracketOrdersSupported { get; }                        //  1 Byte  - Pos 245
            public byte UseIntegerPriceOrderMessages { get; }                  //  1 Byte  - Pos 246
            public byte UsesMultiplePositionsPerSymbolAndTradeAccount { get; } //  1 Byte  - Pos 247
            public byte MarketDataSupported { get; }                           //  1 Byte  - Pos 248

            /// <summary>
            /// Logon Request Msg
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public LogonResponse(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                ProtocolVersion = BitConverter.ToInt32(payload, 0);
                Result = (Protocol.LogonStatus)BitConverter.ToInt32(payload, 4);

                var resultText = new byte[Protocol.TextDescriptionLength];
                Buffer.BlockCopy(payload, 8, resultText, 0, Protocol.TextDescriptionLength);
                ResultText = Utils.GetCleanString(resultText);

                var reconnectAddress = new byte[Protocol.ReconnectAddressLength];
                Buffer.BlockCopy(payload, 104, reconnectAddress, 0, Protocol.ReconnectAddressLength);
                ReconnectAddress = Utils.GetCleanString(reconnectAddress);

                Integer1 = BitConverter.ToInt32(payload, 168);

                var serverName = new byte[Protocol.ServerNameLength];
                Buffer.BlockCopy(payload, 172, serverName, 0, Protocol.ServerNameLength);
                ServerName = Utils.GetCleanString(serverName);

                MarketDepthUpdatesBestBidAndAsk = payload[232];
                TradingIsSupported = payload[233];
                OcoOrdersSupported = payload[234];
                OrderCancelReplaceSupported = payload[235];

                var symbolExchangeDelimiter = new byte[Protocol.SymbolExchangeDelimiterLength];
                Buffer.BlockCopy(payload, 236, symbolExchangeDelimiter, 0, Protocol.SymbolExchangeDelimiterLength);
                SymbolExchangeDelimiter = Utils.GetCleanString(symbolExchangeDelimiter);

                SecurityDefinitionsSupported = payload[240];
                HistoricalPriceDataSupported = payload[241];
                ResubscribeWhenMarketDataFeedAvailable = payload[242];
                MarketDepthIsSupported = payload[243];
                OneHistoricalPriceDataRequestPerConnection = payload[244];
                BracketOrdersSupported = payload[245];
                UseIntegerPriceOrderMessages = payload[246];
                UsesMultiplePositionsPerSymbolAndTradeAccount = payload[247];
                MarketDataSupported = payload[248];

            }

        }
    }
}
