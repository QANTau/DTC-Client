using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Historical Price Data Response Header Msg
        /// </summary>
        public class HistoricalPriceDataResponseHeader : Header
        {
            #region C++ Struct
            //int32 RequestID = 1;
            //HistoricalDataIntervalEnum RecordInterval = 2;
            //uint32 UseZLibCompression = 3;
            //uint32 NoRecordsToReturn = 4;
            //float IntToFloatPriceDivisor = 5;
            #endregion

            public int RequestId { get; }                                       //  4 Bytes - Pos 0
            public Protocol.HistoricalDataInterval RecordInterval { get; }      //  4 Bytes - Pos 4
            public UInt32 UseZLibCompression { get; }                           //  4 Bytes - Pos 8
            public UInt32 NoRecordsToReturn { get; }                            //  4 Bytes - Pos 12
            public float IntToFloatPriceDivisor { get; }                        //  4 Bytes - Pos 16

            /// <summary>
            /// Historical Price Data Response Header Msg
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public HistoricalPriceDataResponseHeader(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                RequestId = BitConverter.ToInt32(payload, 0);
                RecordInterval = (Protocol.HistoricalDataInterval)BitConverter.ToInt32(payload, 4);
                UseZLibCompression = BitConverter.ToUInt32(payload, 8);
                NoRecordsToReturn = BitConverter.ToUInt32(payload, 12);

                if (Size == 24)
                    IntToFloatPriceDivisor = BitConverter.ToSingle(payload, 16);
            }
        }



    }
}
