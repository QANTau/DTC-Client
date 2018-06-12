
using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Historical Price Data Reject Message
        /// </summary>
        public class HistoricalPriceDataReject : JsonHeader
        {
            #region C++ Struct
            //int32_t RequestID;
            //char RejectText[TEXT_DESCRIPTION_LENGTH];
            //HistoricalPriceDataRejectReasonCodeEnum RejectReasonCode;
            //uint16_t RetryTimeInSeconds;
            #endregion

            public int RequestID { get; set; }
            public string RejectText { get; set; }
            public Protocol.HistoricalPriceDataRejectReasonCode RejectReasonCode { get; set; }
            public ushort RetryTimeInSeconds { get; set; }

        }



    }
}
