using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Encoding Response Message
        /// </summary>
        public class EncodingResponse : BinaryHeader
        {
            #region C++ Struct
            //uint16_t Size;
            //uint16_t Type;

            //int32_t ProtocolVersion;
            //EncodingEnum Encoding;
            #endregion

            public int ProtocolVersion { get; }                 // 4 Bytes - Pos 4
            public Protocol.Encoding Encoding { get; }          // 4 Bytes - Pos 8
            public string ProtocolType { get; }                 // 4 Bytes - Pos 12

            /// <inheritdoc />
            /// <summary>
            /// Encoding Response Message
            /// </summary>
            /// <param name="packet"></param>
            public EncodingResponse(byte[] packet)
            {
                // Header
                Size = BitConverter.ToUInt16(packet, 0);
                Type = (Protocol.MessageType)BitConverter.ToUInt16(packet, 2);

                // Payload
                ProtocolVersion = BitConverter.ToInt32(packet, 4);
                Encoding = (Protocol.Encoding)BitConverter.ToInt32(packet, 8);

                var protocolType = new byte[4];
                Buffer.BlockCopy(packet, 12, protocolType, 0, 4);
                ProtocolType = Utils.GetCleanString(protocolType);
            }
        }



    }
}
