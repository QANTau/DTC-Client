using Newtonsoft.Json.Linq;

namespace QANT.DTC
{
    public static partial class Utils
    {
        /// <summary>
        /// Identify Message Type
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public static Protocol.MessageType GetMessageType(byte[] packet)
        {
            var message = JObject.Parse(GetString(packet));

            ushort.TryParse((string)message["Type"], out var messageType);
            return (Protocol.MessageType)messageType;
        }


    }
}
