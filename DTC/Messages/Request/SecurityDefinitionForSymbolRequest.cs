using System;
using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Security Definition For Symbol Request Message
        /// </summary>
        public class SecurityDefinitionForSymbolRequest : JsonHeader
        {
            #region C++ Struct
            //int32_t RequestID;
            //char Symbol[SYMBOL_LENGTH];
            //char Exchange[EXCHANGE_LENGTH];
            #endregion

            public int RequestID { get; }
            public string Symbol { get; }
            public string Exchange { get; }

            /// <summary>
            /// Security Definition For Symbol Request Message
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
                Type = Protocol.MessageType.SecurityDefinitionForSymbolRequest;

                // Payload
                RequestID = requestId;
                Symbol = symbol;
                Exchange = exchange;
            }
        }
    }
}
