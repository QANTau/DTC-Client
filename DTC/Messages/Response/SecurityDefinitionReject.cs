using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Security Definition Reject Message
        /// </summary>
        public class SecurityDefinitionReject : JsonHeader
        {
            #region C++ Struct
            //int32_t RequestID;
            //char RejectText[TEXT_DESCRIPTION_LENGTH];
            #endregion

            public int RequestId { get; set; }
            public string RejectText { get; set; }
        }

    }
}
