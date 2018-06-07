using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Encoding Response Msg
        /// </summary>
        public class HistoricalPriceDataRecordResponse : Header
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

            public int RequestId { get; }                                       // 4 Bytes - Pos 0
            public long StartDateTime { get; }                                  // 8 Bytes - Pos 4
            public double OpenPrice { get; }                                    // 8 Bytes - Pos 12
            public double HighPrice { get; }                                    // 8 Bytes - Pos 20
            public double LowPrice { get; }                                     // 8 Bytes - Pos 28
            public double LastPrice { get; }                                    // 8 Bytes - Pos 36
            public double Volume { get; }                                       // 8 Bytes - Pos 44
            public UInt32 NumTrades { get; }                                    // 4 Bytes - Pos 56
            public UInt32 OpenInterest { get; }                                 // 4 Bytes - Pos 52
            public double BidVolume { get; }                                    // 8 Bytes - Pos 60
            public double AskVolume { get; }                                    // 8 Bytes - Pos 68
            public byte IsFinalRecord { get; }                                  // 1 Byte  - Pos 76

            public DateTime DateTime
            {
                get
                {
                    return Utils.WindowsDateTime(StartDateTime);
                }
            }

            /// <summary>
            /// Encoding Response Msg
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public HistoricalPriceDataRecordResponse(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                RequestId = BitConverter.ToInt32(payload, 0);
                StartDateTime = BitConverter.ToInt64(payload, 4);
                OpenPrice = BitConverter.ToDouble(payload, 12);         OpenPrice = Math.Round(OpenPrice, 5);
                HighPrice = BitConverter.ToDouble(payload, 20);         HighPrice = Math.Round(HighPrice, 5);
                LowPrice = BitConverter.ToDouble(payload, 28);          LowPrice = Math.Round(LowPrice, 5);
                LastPrice = BitConverter.ToDouble(payload, 36);         LastPrice = Math.Round(LastPrice, 5);
                Volume = BitConverter.ToDouble(payload, 44);
                NumTrades = BitConverter.ToUInt32(payload, 52);
                OpenInterest = BitConverter.ToUInt32(payload, 56);
                BidVolume = BitConverter.ToDouble(payload, 60);
                AskVolume = BitConverter.ToDouble(payload, 68);
                IsFinalRecord = payload[76];

            }
        }



    }
}
