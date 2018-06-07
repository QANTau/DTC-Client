using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Historical Price Data Request Msg
        /// </summary>
        public class HistoricalPriceDataRequest : Header
        {
            #region C++ Struct
            //int32_t RequestID;
            //char Symbol[SYMBOL_LENGTH];
            //char Exchange[EXCHANGE_LENGTH];
            //HistoricalDataIntervalEnum RecordInterval;
            //t_DateTime StartDateTime;
            //t_DateTime EndDateTime;
            //uint32_t MaxDaysToReturn;
            //uint8_t UseZLibCompression;
            //uint8_t RequestDividendAdjustedStockData;
            //uint8_t Flag_1;
            #endregion

            public int RequestId { get; }                                       //  4 Bytes - Pos 0
            public string Symbol { get; }                                       // 64 Bytes - Pos 4
            public string Exchange { get; }                                     // 16 Bytes - Pos 68
            public Protocol.HistoricalDataInterval RecordInterval { get; }      //  4 Bytes - Pos 84
            public long StartDateTime { get; }                                  //  8 Bytes - Pos 92
            public long EndDateTime { get; }                                    //  8 Bytes - Pos 100
            public uint MaxDaysToReturn { get; }                                //  4 Bytes - Pos 108
            public byte UseZLibCompression { get; }                             //  1 Byte  - Pos 112
            public byte RequestDividendAdjustedStockData { get; }               //  1 Byte  - Pos 113
            public byte Flag1 { get; }                                         //  1 Byte  - Pos 114

            /// <inheritdoc />
            public HistoricalPriceDataRequest(
                int id, 
                string symbol, 
                string exchange, 
                Protocol.HistoricalDataInterval interval,
                DateTime start,
                DateTime end)
            {
                // Header
                Size = 118;
                Type = Protocol.MessageType.HistoricalPriceDataRequest;

                // Payload
                RequestId = id;
                Symbol = symbol;
                Exchange = exchange;
                RecordInterval = interval;
                StartDateTime = Utils.UnixDateTime(start);
                EndDateTime = Utils.UnixDateTime(end);
                MaxDaysToReturn = 0;
                UseZLibCompression = 0;
                RequestDividendAdjustedStockData = 0;
                Flag1 = 0;
            }

            /// <summary>
            /// Historical Price Data Request Msg
            /// </summary>
            public HistoricalPriceDataRequest(
                int id,
                string symbol,
                string exchange,
                Protocol.HistoricalDataInterval interval,
                uint numDays)
            {
                // Header
                Size = 118;
                Type = Protocol.MessageType.HistoricalPriceDataRequest;

                // Payload
                RequestId = id;
                Symbol = symbol;
                Exchange = exchange;
                RecordInterval = interval;
                StartDateTime = Utils.CurrentUnixDateTime();
                EndDateTime = Utils.CurrentUnixDateTime();
                MaxDaysToReturn = numDays;
                UseZLibCompression = 0;
                RequestDividendAdjustedStockData = 0;
                Flag1 = 0;
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(BitConverter.GetBytes(RequestId),
                                            Utils.AsPaddedBytes(Symbol, Protocol.SymbolLength),
                                            Utils.AsPaddedBytes(Exchange, Protocol.ExchangeLength),
                                            BitConverter.GetBytes((int)RecordInterval),
                                            BitConverter.GetBytes(StartDateTime),
                                            BitConverter.GetBytes(EndDateTime),
                                            BitConverter.GetBytes(MaxDaysToReturn),
                                            BitConverter.GetBytes(UseZLibCompression),
                                            BitConverter.GetBytes(RequestDividendAdjustedStockData),
                                            BitConverter.GetBytes(Flag1));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }

        }
    }
}
