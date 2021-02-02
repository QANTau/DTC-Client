using System;
using System.Diagnostics;
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
            try
            {
                var message = JObject.Parse(GetString(packet));
            }
            catch (Exception ex)
            {
                var msg = ex.Message + " processing '" + GetString(packet) + "'";
                Debugger.Break();
            }

            //ushort.TryParse((string)message["Type"], out var messageType);
            ushort.TryParse((string)JObject.Parse(GetString(packet))["Type"], out var messageType);
            return (Protocol.MessageType)messageType;
        }


    }
}
