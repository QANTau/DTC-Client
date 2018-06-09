using System;

namespace QANT.DTC
{


    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Security Definition Response Message
        /// </summary>
        public class SecurityDefinitionResponse : JsonHeader
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

            public int RequestId { get; set; }
            public string Symbol { get; set; }
            public string Exchange { get; set; }
            public Protocol.SecurityType SecurityType { get; set; }
            public string Description { get; set; }
            public float MinPriceIncrement { get; set; }
            public Protocol.PriceDisplayFormat PriceDisplayFormat { get; set; }
            public float CurrencyValuePerIncrement { get; set; }
            public byte IsFinalMessage { get; set; }
            public float FloatToIntPriceMultiplier { get; set; }
            public float IntToFloatPriceDivisor { get; set; }
            public string UnderlyingSymbol { get; set; }
            public byte UpdatesBidAskOnly { get; set; }
            public float StrikePrice { get; set; }
            public Protocol.PutOrCall PutOrCall { get; set; }
            public int ShortInterest { get; set; }
            public uint SecurityExpirationDate { get; set; }
            public float BuyRolloverInterest { get; set; }
            public float SellRolloverInterest { get; set; }
            public float EarningsPerShare { get; set; }
            public uint SharesOutstanding { get; set; }
            public float IntToFloatQuantityDivisor { get; set; }
            public byte HasMarketDepthData { get; set; }
            public float DisplayPriceMultiplier { get; set; }
            public string ExchangeSymbol { get; set; }

            // Not in the protocol specification but provided in Json responses
            public string Currency { get; set; }
        }
    }
}
