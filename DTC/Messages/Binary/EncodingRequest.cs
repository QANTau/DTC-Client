using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Encoding Request Message
        /// </summary>
        public class EncodingRequest : BinaryHeader
        {
            #region C++ Struct
            //int32_t ProtocolVersion;
            //EncodingEnum Encoding;
            #endregion

            public int ProtocolVersion { get; }                         // 4 Bytes - Pos 0
            public Protocol.Encoding Encoding { get;  }                 // 4 Bytes - Pos 4
            public string ProtocolType { get; }                         // 4 Bytes - Pos 8

            /// <inheritdoc />
            /// <summary>
            /// Encoding Request Message
            /// </summary>
            public EncodingRequest()
            {
                // Header
                Size = 16;
                Type = Protocol.MessageType.EncodingRequest;

                // Payload
                ProtocolVersion = Protocol.CurrentVersion;
                Encoding = Protocol.Encoding.JsonEncoding;
                ProtocolType = Utils.GetString(Utils.AsPaddedBytes(Protocol.ProtocolType, 4));
            }

            /// <summary>
            /// Binary Formatted Message
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
