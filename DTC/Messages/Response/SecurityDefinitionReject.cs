using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Security Definition Reject Msg
        /// </summary>
        public class SecurityDefinitionReject : Header
        {
            #region C++ Struct
            //int32_t RequestID;
            //char RejectText[TEXT_DESCRIPTION_LENGTH];
            #endregion

            public int RequestId { get; }                                                       //  4 Bytes - Pos 0
            public string RejectText { get; }                                                   // 96 Bytes - Pos 4

            /// <summary>
            /// Security Definition Reject Msg
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public SecurityDefinitionReject(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                RequestId = BitConverter.ToInt32(payload, 0);

                var rejectText = new byte[Protocol.TextDescriptionLength];
                Buffer.BlockCopy(payload, 4, rejectText, 0, Protocol.TextDescriptionLength);
                RejectText = Utils.GetCleanString(rejectText);
            }
        }



    }
}
