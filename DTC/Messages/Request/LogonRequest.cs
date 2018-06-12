using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Logon Request Message
        /// </summary>
        public class LogonRequest : JsonHeader
        {
            #region C++ Struct
            //int32_t ProtocolVersion;
            //char Username[USERNAME_PASSWORD_LENGTH];
            //char Password[USERNAME_PASSWORD_LENGTH];
            //char GeneralTextData[GENERAL_IDENTIFIER_LENGTH];
            //int32_t Integer_1;
            //int32_t Integer_2;
            //int32_t HeartbeatIntervalInSeconds;
            //TradeModeEnum TradeMode;
            //char TradeAccount[TRADE_ACCOUNT_LENGTH];
            //char HardwareIdentifier[GENERAL_IDENTIFIER_LENGTH];
            //char ClientName[32];
            #endregion
            
            public int ProtocolVersion { get; }
            public string Username { get; }
            public string Password { get; }
            public string GeneralTextData { get; }
            public int Integer_1 { get; }
            public int Integer_2 { get; }
            public int HeartbeatIntervalInSeconds { get; }
            public Protocol.TradeMode TradeMode { get; }
            public string TradeAccount { get; }
            public string HardwareIdentifier { get; }
            public string ClientName { get; }

            /// <inheritdoc />
            /// <summary>
            /// Logon Request Message
            /// </summary>
            /// <param name="user"></param>
            /// <param name="password"></param>
            /// <param name="isHistorical"></param>
            public LogonRequest(string user, string password, bool isHistorical = false)
            {
                // Header
                Type = Protocol.MessageType.LogonRequest;
                
                // Payload
                ProtocolVersion = Protocol.CurrentVersion;
                Username = user;
                Password = password;
                GeneralTextData = "QANT C# DTC Client";
                Integer_1 = 0;
                Integer_2 = 0;
                HeartbeatIntervalInSeconds = isHistorical ? 0 : Protocol.HeartbeatInterval;
                TradeMode = Protocol.TradeMode.TradeModeUnset;
                TradeAccount = "";
                HardwareIdentifier = "";
                ClientName = Environment.MachineName;
            }

            public byte[] Packet()
            {
                return Utils.AsBytes(JsonConvert.SerializeObject(this));
            }

        }
    }
}
