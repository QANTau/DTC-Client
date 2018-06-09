using System;
using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Historical Price Data Request Message
        /// </summary>
        public class HistoricalPriceDataRequest : JsonHeader
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

            public int RequestId { get; }
            public string Symbol { get; }
            public string Exchange { get; }
            public Protocol.HistoricalDataInterval RecordInterval { get; }
            public long StartDateTime { get; }
            public long EndDateTime { get; }
            public uint MaxDaysToReturn { get; }
            public byte UseZLibCompression { get; }
            public byte RequestDividendAdjustedStockData { get; }
            public byte Flag_1 { get; }

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
                Flag_1 = 0;
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
                Flag_1 = 0;
            }
        }
    }
}
