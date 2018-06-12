using System;
using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Encoding Response Message
        /// </summary>
        public class HistoricalPriceDataRecordResponse : JsonHeader
        {
            #region C++ Struct
            //int32_t RequestID;
            //t_DateTime StartDateTime;
            //double OpenPrice;
            //double HighPrice;
            //double LowPrice;
            //double LastPrice;
            //double Volume;
            //unit32 NumTrades;
            //double BidVolume;
            //double AskVolume;
            //uint8_t IsFinalRecord;
            #endregion

            public int RequestID { get; set; }
            public long StartDateTime { get; set; }
            public double OpenPrice { get; set; }
            public double HighPrice { get; set; }
            public double LowPrice { get; set; }
            public double LastPrice { get; set; }
            public double Volume { get; set; }
            public uint NumTrades { get; set; }
            public uint OpenInterest { get; set; }
            public double BidVolume { get; set; }
            public double AskVolume { get; set; }
            public byte IsFinalRecord { get; set; }

            public DateTime DateTime()
            {
                return Utils.WindowsDateTime(StartDateTime);
            }

        }



    }
}
