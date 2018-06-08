using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Symbol Search Request Msg
        /// </summary>
        public class SymbolSearchRequest : Header
        {

            #region C++ Struct
            //int32_t RequestID;
            //char SearchText[SYMBOL_DESCRIPTION_LENGTH];   64
            //char Exchange[EXCHANGE_LENGTH];               16
            //SecurityTypeEnum SecurityType;                int32_t
            //SearchTypeEnum SearchType;                    int32_t
            #endregion

            public int RequestId { get; }                               //  4 Bytes - Pos 0
            public string SearchText { get; }                           // 64 Bytes - Pos 4
            public string Exchange { get; }                             // 16 Bytes - Pos 68
            public Protocol.SecurityType SecurityTypeEnum { get; }      //  4 Bytes - Pos 84
            public Protocol.SearchType SearchTypeEnum { get; }          //  4 Bytes - Pos 88

            /// <summary>
            /// Symbol Search Request Msg
            /// </summary>
            /// <param name="requestId"></param>
            /// <param name="searchText"></param>
            /// <param name="securityType"></param>
            /// <param name="searchType"></param>
            /// <param name="exchange"></param>
            public SymbolSearchRequest(
                int requestId,
                string searchText,
                Protocol.SecurityType securityType = Protocol.SecurityType.SecurityTypeForex,
                Protocol.SearchType searchType = Protocol.SearchType.SearchTypeBySymbol,
                string exchange = "")
            {
                // Header
                Size = 96;
                Type = Protocol.MessageType.SymbolSearchRequest;

                // Payload
                RequestId = requestId;  
                SearchText = searchText;
                SecurityTypeEnum = securityType;
                SearchTypeEnum = searchType;
                Exchange = exchange;
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(BitConverter.GetBytes(RequestId),
                                            Utils.AsPaddedBytes(SearchText, Protocol.SymbolDescriptionLength),
                                            Utils.AsPaddedBytes(Exchange, Protocol.ExchangeLength),
                                            BitConverter.GetBytes((int)SecurityTypeEnum),
                                            BitConverter.GetBytes((int)SearchTypeEnum));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }

        }
    }
}
