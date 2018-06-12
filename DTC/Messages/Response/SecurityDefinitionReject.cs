using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
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

            public int RequestID { get; set; }
            public string RejectText { get; set; }
        }

    }
}
