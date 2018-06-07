using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Request/Response Header (Common Elements)
        /// </summary>
        public class Header
        {
            #region C++ Struct
            //uint16_t Size;
            //uint16_t Type;
            #endregion

            public ushort Size { get; set; }                  // 2 Bytes - Pos 0
            public Protocol.MessageType Type { get; set; }    // 2 Bytes - Pos 2

            /// <summary>
            /// Request/Response Header (Common Elements)
            /// </summary>
            public Header()
            { }

            /// <summary>
            /// Request/Response Header (Common Elements)
            /// </summary>
            public Header(byte[] rawHeader)
            {
                SetHeader(rawHeader);
            }

            /// <summary>
            /// Binary Formatted Header
            /// </summary>
            /// <returns></returns>
            internal byte[] GetHeader()
            {
                return Utils.Combine(
                    BitConverter.GetBytes(Size), 
                    BitConverter.GetBytes((ushort)Type));
            }

            /// <summary>
            /// Set the Header
            /// </summary>
            /// <param name="header"></param>
            public void SetHeader(byte[] header)
            {
                Size = BitConverter.ToUInt16(header, 0);
                Type = (Protocol.MessageType)BitConverter.ToUInt16(header, 2);
            }

 
        }
    }
}
