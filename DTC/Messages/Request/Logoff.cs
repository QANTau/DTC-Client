
namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Logoff Request Message
        /// </summary>
        public class LogoffRequest : JsonHeader
        {
            #region C++ Struct
            //char Reason[TEXT_DESCRIPTION_LENGTH];
            //uint8_t DoNotReconnect;
            #endregion

            public string Reason { get; }
            public ushort DoNotReconnect { get; }

            /// <summary>
            /// Logoff Request Message
            /// </summary>
            /// <param name="reason"></param>
            public LogoffRequest(string reason)
            {

                // Header
                Type = Protocol.MessageType.Logoff;

                // Payload
                Reason = reason;
                DoNotReconnect = 0;
            }
        }
    }
}
