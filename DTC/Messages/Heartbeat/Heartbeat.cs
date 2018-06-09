using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Heartbeat Request/Response Message
        /// </summary>
        public class Heartbeat : JsonHeader
        {
            #region C++ Struct

            //uint32_t NumDroppedMessages;
            //t_DateTime CurrentDateTime;

            #endregion

            public int NumDroppedMessages { get; set; }
            public long CurrentDateTime { get; set; }

            /// <summary>
            /// Heartbeat Request/Response Message 
            /// </summary>
            public Heartbeat(int numNumDroppedMessages = 0)
            {
                // Header
                Type = Protocol.MessageType.Heartbeat;

                // Payload
                NumDroppedMessages = numNumDroppedMessages;
                CurrentDateTime = Utils.CurrentUnixDateTime();
            }

            public DateTime DateTime()
            {
                return Utils.WindowsDateTime(CurrentDateTime);
            }
        }
    }
}
