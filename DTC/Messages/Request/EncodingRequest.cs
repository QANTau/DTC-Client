using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Encoding Request Msg
        /// </summary>
        public class EncodingRequest : Header
        {
            #region C++ Struct
            //int32_t ProtocolVersion;
            //EncodingEnum Encoding;
            #endregion

            public int ProtocolVersion { get; }                         // 4 Bytes - Pos 0
            public Protocol.Encoding Encoding { get;  }                 // 4 Bytes - Pos 4
            public string ProtocolType { get; }                         // 4 Bytes - Pos 8

            /// <inheritdoc />
            public EncodingRequest()
            {
                // Header
                Size = 16;
                Type = Protocol.MessageType.EncodingRequest;

                // Payload
                ProtocolVersion = Protocol.CurrentVersion;
                Encoding = Protocol.Encoding.BinaryEncoding;
                ProtocolType = Utils.GetString(Utils.AsPaddedBytes(Protocol.ProtocolType, 4));
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(BitConverter.GetBytes(ProtocolVersion),
                                            BitConverter.GetBytes((int)Encoding),
                                            Utils.GetBytes(ProtocolType));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }
        }
    }
}
