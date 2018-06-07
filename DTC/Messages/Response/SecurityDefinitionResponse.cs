using System;

namespace QANT.DTC
{


    public partial class Messages
    {
        /// <summary>
        /// Security Definition Response Msg
        /// </summary>
        public class SecurityDefinitionResponse : Header
        {
            #region C++ Struct
            //int32_t RequestID;
            //char Symbol[SYMBOL_LENGTH];
            //char Exchange[EXCHANGE_LENGTH];
            //SecurityTypeEnum SecurityType;
            //char Description[SYMBOL_DESCRIPTION_LENGTH];
            //float MinPriceIncrement;
            //PriceDisplayFormatEnum PriceDisplayFormat;
            //float CurrencyValuePerIncrement;
            //uint8_t IsFinalMessage;
            //float FloatToIntPriceMultiplier;
            //float IntToFloatPriceDivisor;
            //char UnderlyingSymbol[UNDERLYING_SYMBOL_LENGTH];
            //uint8_t UpdatesBidAskOnly;
            //float StrikePrice;
            //PutOrCallEnum PutOrCall;
            //uint32_t ShortInterest;
            //t_DateTime4Byte SecurityExpirationDate;
            //float BuyRolloverInterest;
            //float SellRolloverInterest;
            //float EarningsPerShare;
            //uint32_t SharesOutstanding;
            //float IntToFloatQuantityDivisor;
            //uint8_t HasMarketDepthData;
            //float DisplayPriceMultiplier;
            //char ExchangeSymbol[SYMBOL_LENGTH];
            #endregion

            public int RequestId { get; }                                   //  4 Bytes - Pos 0
            public string Symbol { get; }                                   // 64 Bytes - Pos 4

            /// <summary>
            /// Exchange
            /// </summary>
            public string Exchange { get; }                                 // 16 Bytes - Pos 68
            public Protocol.SecurityType SecurityType { get; }              //  4 Bytes - Pos 84
            public string Description { get; }                              // 64 Bytes - Pos 88
            public float MinPriceIncrement { get; }                         //  4 Bytes - Pos 152
            public Protocol.PriceDisplayFormat PriceDisplayFormat { get; }  //  4 Bytes - Pos 156
            public float CurrencyValuePerIncrement { get; }                 //  4 Bytes - Pos 160
            public byte IsFinalMessage { get; }                             //  1 Byte  - Pos 164
            public float FloatToIntPriceMultiplier { get; }                 //  4 Bytes - Pos 165
            public float IntToFloatPriceDivisor { get; }                    //  4 Bytes - Pos 169
            public string UnderlyingSymbol { get; }                         // 32 Bytes - Pos 173
            public byte UpdatesBidAskOnly { get; }                          //  1 Byte  - Pos 205
            public float StrikePrice { get; }                               //  4 Bytes - Pos 206
            public Protocol.PutOrCall PutOrCall { get; }                    //  1 Byte  - Pos 210
            public int ShortInterest { get; }                               //  4 Bytes - Pos 211
            public uint SecurityExpirationDate { get; }                     //  4 Bytes - Pos 215
            public float BuyRolloverInterest { get; }                       //  4 Bytes - Pos 219
            public float SellRolloverInterest { get; }                      //  4 Bytes - Pos 223
            public float EarningsPerShare { get; }                          //  4 Bytes - Pos 227
            public uint SharesOutstanding { get; }                          //  4 Bytes - Pos 231
            public float IntToFloatQuantityDivisor { get; }                 //  4 Bytes - Pos 235
            public byte HasMarketDepthData { get; }                         //  1 Byte  - Pos 239
            public float DisplayPriceMultiplier { get; }                    //  4 Bytes - Pos 240
            public string ExchangeSymbol { get; }                           // 64 Bytes - Pos 244


            /// <summary>
            /// Security Definition Response
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public SecurityDefinitionResponse(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                RequestId = BitConverter.ToInt32(payload, 0);

                var symbol = new byte[Protocol.SymbolLength];
                Buffer.BlockCopy(payload, 4, symbol, 0, Protocol.SymbolLength);
                Symbol = Utils.GetCleanString(symbol);

                var exchange = new byte[Protocol.ExchangeLength];
                Buffer.BlockCopy(payload, 68, exchange, 0, Protocol.ExchangeLength);
                Exchange = Utils.GetCleanString(exchange);

                SecurityType = (Protocol.SecurityType)BitConverter.ToInt32(payload, 84);

                var description = new byte[Protocol.SymbolDescriptionLength];
                Buffer.BlockCopy(payload, 88, description, 0, Protocol.SymbolDescriptionLength);
                Description = Utils.GetCleanString(description);

                MinPriceIncrement = BitConverter.ToSingle(payload, 152);
                PriceDisplayFormat = (Protocol.PriceDisplayFormat)BitConverter.ToInt32(payload, 156);
                CurrencyValuePerIncrement = BitConverter.ToSingle(payload, 160);
                IsFinalMessage = payload[164];
                FloatToIntPriceMultiplier = BitConverter.ToSingle(payload, 165);
                IntToFloatPriceDivisor = BitConverter.ToSingle(payload, 169);

                var underlyingSymbol = new byte[Protocol.UnderlyingSymbolLength];
                Buffer.BlockCopy(payload, 173, underlyingSymbol, 0, Protocol.UnderlyingSymbolLength);
                UnderlyingSymbol = Utils.GetCleanString(underlyingSymbol);
                
                UpdatesBidAskOnly = payload[205];
                StrikePrice = BitConverter.ToSingle(payload, 206);
                PutOrCall = (Protocol.PutOrCall)BitConverter.ToInt32(payload, 210);
                ShortInterest = BitConverter.ToInt32(payload, 211);
                SecurityExpirationDate = BitConverter.ToUInt32(payload, 215);
                BuyRolloverInterest = BitConverter.ToSingle(payload, 219);
                SellRolloverInterest = BitConverter.ToSingle(payload, 223);
                EarningsPerShare = BitConverter.ToSingle(payload, 227);
                SharesOutstanding = BitConverter.ToUInt32(payload, 231);
                IntToFloatQuantityDivisor = BitConverter.ToSingle(payload, 235);
                HasMarketDepthData = payload[239];
                DisplayPriceMultiplier = BitConverter.ToSingle(payload, 240);

                var exchangeSymbol = new byte[Protocol.SymbolLength];
                Buffer.BlockCopy(payload, 244, exchangeSymbol, 0, Protocol.SymbolLength);
                ExchangeSymbol = Utils.GetCleanString(exchangeSymbol);

            }

        }
    }
}
