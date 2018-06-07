using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Historical Price Data Reject Msg
        /// </summary>
        public class HistoricalPriceDataReject : Header
        {
            #region C++ Struct
            //int32_t RequestID;
            //char RejectText[TEXT_DESCRIPTION_LENGTH];
            //HistoricalPriceDataRejectReasonCodeEnum RejectReasonCode;
            //uint16_t RetryTimeInSeconds;
            #endregion

            public int RequestId { get; }                                                       //  4 Bytes - Pos 0
            public string RejectText { get; }                                                   // 96 Bytes - Pos 4
            public Protocol.HistoricalPriceDataRejectReasonCode RejectReasonCode { get; }       //  2 Bytes - Pos 100
            public ushort RetryTimeInSeconds { get; }                                           //  2 Bytes - Pos 102

            /// <summary>
            /// Historical Price Data Reject Msg
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public HistoricalPriceDataReject(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                RequestId = BitConverter.ToInt32(payload, 0);

                var rejectText = new byte[Protocol.TextDescriptionLength];
                Buffer.BlockCopy(payload, 4, rejectText, 0, Protocol.TextDescriptionLength);
                RejectText = Utils.GetCleanString(rejectText);

                RejectReasonCode = (Protocol.HistoricalPriceDataRejectReasonCode)BitConverter.ToInt16(payload, 100);

                RetryTimeInSeconds = BitConverter.ToUInt16(payload, 102);

            }
        }



    }
}
