using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Logoff Request Msg
        /// </summary>
        public class LogoffRequest : Header
        {
            #region C++ Struct
            //char Reason[TEXT_DESCRIPTION_LENGTH];
            //uint8_t DoNotReconnect;
            #endregion

            public string Reason;                               // 96 Bytes - Pos 0
            public ushort DoNotReconnect;                       //  2 Bytes - Pos 96

            /// <summary>
            /// Logoff Request Msg
            /// </summary>
            /// <param name="reason"></param>
            public LogoffRequest(string reason)
            {

                // Header
                Size = 102;
                Type = Protocol.MessageType.Logoff;

                // Payload
                Reason = reason;
                DoNotReconnect = 0;
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(Utils.AsPaddedBytes(Reason, Protocol.TextDescriptionLength),
                                            BitConverter.GetBytes(DoNotReconnect));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }
        }
    }
}
