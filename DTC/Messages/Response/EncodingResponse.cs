using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Encoding Response Msg
        /// </summary>
        public class EncodingResponse : Header
        {
            #region C++ Struct
            //int32_t ProtocolVersion;
            //EncodingEnum Encoding;
            #endregion

            public int ProtocolVersion { get; }                 // 4 Bytes - Pos 0
            public Protocol.Encoding Encoding { get; }          // 4 Bytes - Pos 4
            public string ProtocolType { get; }                 // 4 Bytes - Pos 8

            /// <summary>
            /// Encoding Response Msg
            /// </summary>
            /// <param name="header"></param>
            /// <param name="payload"></param>
            public EncodingResponse(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                ProtocolVersion = BitConverter.ToInt32(payload, 0);
                Encoding = (Protocol.Encoding)BitConverter.ToInt32(payload, 4);

                var protocolType = new byte[4];
                Buffer.BlockCopy(payload, 8, protocolType, 0, 4);
                ProtocolType = Utils.GetCleanString(protocolType);
            }
        }



    }
}
