using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// General Log Msg
        /// </summary>
        public class GeneralLogMessage : Header
        {

            #region C++ Struct
            //char MessageText[128];
            #endregion

            public string MessageText { get; }                 // 128 Bytes - Pos 0

            /// <summary>
            /// General Log Msg
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public GeneralLogMessage(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                var msg = new byte[128];
                Buffer.BlockCopy(payload, 172, msg, 0, 128);
                MessageText = Utils.GetCleanString(msg);
            }


        }
    }
}
