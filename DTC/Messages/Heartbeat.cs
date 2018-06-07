using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Heartbeat Request/Response Msg
        /// </summary>
        public class Heartbeat : Header
        {
            #region C++ Struct
            //uint32_t NumDroppedMessages;
            //t_DateTime CurrentDateTime;
            #endregion

            public int NumDroppedMessages { get; }              // 4 Bytes - Pos 0
            public long LocalDateTime { get; }                  // 8 Bytes - Pos 4
            public DateTime RemoteDateTime { get; }

            /// <summary>
            /// Heartbeat (Request) Msg 
            /// </summary>
            public Heartbeat()
            {
                // Header
                Size = 16;
                Type = Protocol.MessageType.Heartbeat;

                // Payload
                NumDroppedMessages = Protocol.HeartbeatLossMaximum;
                LocalDateTime = Utils.CurrentUnixDateTime();
            }

            /// <summary>
            /// Heartbeat (Response) Msg 
            /// </summary>
            public Heartbeat(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                NumDroppedMessages = BitConverter.ToInt32(payload, 0);
                RemoteDateTime = Utils.WindowsDateTime(BitConverter.ToInt64(payload, 4));
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(BitConverter.GetBytes(NumDroppedMessages),
                                            BitConverter.GetBytes(LocalDateTime));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }

        }
    }
}
