using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Historical Price Data Response Header Message
        /// </summary>
        public class HistoricalPriceDataResponseHeader : JsonHeader
        {
            #region C++ Struct
            //int32 RequestID = 1;
            //HistoricalDataIntervalEnum RecordInterval = 2;
            //uint32 UseZLibCompression = 3;
            //uint32 NoRecordsToReturn = 4;
            //float IntToFloatPriceDivisor = 5;
            #endregion

            public int RequestId { get; set; }
            public Protocol.HistoricalDataInterval RecordInterval { get; set; }
            public uint UseZLibCompression { get; set; }
            public uint NoRecordsToReturn { get; set; }
            public float IntToFloatPriceDivisor { get; set; }

        }



    }
}
