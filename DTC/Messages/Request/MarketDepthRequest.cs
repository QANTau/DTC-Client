
using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Request Message
        /// </summary>
        public class MarketDepthRequest : JsonHeader
        {

            #region C++ Struct
            //RequestActionEnum RequestAction;
            //uint32_t SymbolID;
            //char Symbol[SYMBOL_LENGTH];
            //char Exchange[EXCHANGE_LENGTH];
            //int32_t NumLevels;
            #endregion

            public Protocol.RequestAction RequestAction { get; }
            public int SymbolID { get; }
            public string Symbol { get; }
            public string Exchange { get; }
            public int NumLevels { get; }

            /// <summary>
            /// Market Data Request Message
            /// </summary>
            /// <param name="symbolId"></param>
            /// <param name="symbol"></param>
            /// <param name="numLevels"></param>
            /// <param name="action"></param>
            /// <param name="exchange"></param>
            public MarketDepthRequest(
                int symbolId,
                string symbol,
                int numLevels,
                Protocol.RequestAction action = Protocol.RequestAction.Subscribe,
                string exchange = "")
            {
                // Header
                Type = Protocol.MessageType.MarketDataRequest;

                // Payload
                RequestAction = action;
                SymbolID = symbolId;
                Symbol = symbol;
                Exchange = exchange;
                NumLevels = numLevels;
            }
        }
    }
}
