using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Logon Request Msg
        /// </summary>
        public class LogonRequest : Header
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
            
            public int ProtocolVersion { get; }                //  4 Bytes - Pos 0
            public string Username { get; }                    // 32 Bytes - Pos 4
            public string Password { get; }                    // 32 Bytes - Pos 36
            public string GeneralTextData { get; }             // 64 Bytes - Pos 68
            public int Integer1 { get; }                      //  4 Bytes - Pos 132
            public int Integer2 { get; }                      //  4 Bytes - Pos 136
            public int HeartbeatIntervalInSeconds { get; }     //  4 Bytes - Pos 140
            public Protocol.TradeMode TradeMode { get; }       //  4 Bytes - Pos 144
            public string TradeAccount { get; }                // 32 Bytes - Pos 148
            public string HardwareIdentifier { get; }          // 64 Bytes - Pos 180
            public string ClientName { get; }                  // 32 Bytes - Pos 244

            /// <summary>
            /// Logon Request Msg
            /// </summary>
            /// <param name="user"></param>
            /// <param name="password"></param>
            public LogonRequest(string user, string password)
            {
                // Header
                Size = 280;
                Type = Protocol.MessageType.LogonRequest;
                
                // Payload
                ProtocolVersion = Protocol.CurrentVersion;
                Username = user;
                Password = password;
                GeneralTextData = "QANT C# DTC Client";
                Integer1 = 0;
                Integer2 = 0;
                HeartbeatIntervalInSeconds = Protocol.HeartbeatInterval;
                TradeMode = Protocol.TradeMode.TradeModeUnset;
                TradeAccount = "";
                HardwareIdentifier = "";
                ClientName = Environment.MachineName;
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(BitConverter.GetBytes(ProtocolVersion),
                                            Utils.AsPaddedBytes(Username, Protocol.UsernamePasswordLength),
                                            Utils.AsPaddedBytes(Password, Protocol.UsernamePasswordLength),
                                            Utils.AsPaddedBytes(GeneralTextData, Protocol.GeneralIdentifierLength),
                                            BitConverter.GetBytes(Integer1),
                                            BitConverter.GetBytes(Integer2),
                                            BitConverter.GetBytes(HeartbeatIntervalInSeconds),
                                            BitConverter.GetBytes((int)TradeMode),
                                            Utils.AsPaddedBytes(TradeAccount, Protocol.TradeAccountLength),
                                            Utils.AsPaddedBytes(HardwareIdentifier, Protocol.GeneralIdentifierLength),
                                            Utils.AsPaddedBytes(ClientName, Protocol.ClientNameLength));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }

        }
    }
}
