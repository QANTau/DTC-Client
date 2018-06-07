using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Security Definition For Symbol Request Msg
        /// </summary>
        public class SecurityDefinitionForSymbolRequest : Header
        {
            #region C++ Struct
            //int32_t RequestID;
            //char Symbol[SYMBOL_LENGTH];
            //char Exchange[EXCHANGE_LENGTH];
            #endregion

            public int RequestId { get; }                       //  4 Bytes - Pos 0
            public string Symbol { get; }                       // 64 Bytes - Pos 4
            public string Exchange { get; }                     // 16 Bytes - Pos 68

            /// <summary>
            /// Security Definition For Symbol Request Msg
            /// </summary>
            /// <param name="requestId"></param>
            /// <param name="symbol"></param>
            /// <param name="exchange"></param>
            public SecurityDefinitionForSymbolRequest(
                int requestId,
                string symbol,
                string exchange)
            {
                // Header
                Size = 88;
                Type = Protocol.MessageType.SecurityDefinitionForSymbolRequest;

                // Payload
                RequestId = requestId;
                Symbol = symbol;
                Exchange = exchange;
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(BitConverter.GetBytes(RequestId),
                                            Utils.AsPaddedBytes(Symbol, Protocol.SymbolLength),
                                            Utils.AsPaddedBytes(Exchange, Protocol.ExchangeLength));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }



        }
    }
}
