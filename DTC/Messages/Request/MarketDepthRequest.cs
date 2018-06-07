using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Market Data Request Msg
        /// </summary>
        public class MarketDepthRequest : Header
        {

            #region C++ Struct
            //RequestActionEnum RequestAction;
            //uint32_t SymbolID;
            //char Symbol[SYMBOL_LENGTH];
            //char Exchange[EXCHANGE_LENGTH];
            //int32_t NumLevels;
            #endregion

            public Protocol.RequestAction RequestAction { get; }        //  4 Bytes - Pos 0
            public int SymbolId { get; }                                //  4 Bytes - Pos 4
            public string Symbol { get; }                               // 64 Bytes - Pos 8
            public string Exchange { get; }                             // 16 Bytes - Pos 72
            public int NumLevels { get; }                               //  4 Bytes - Pos 88

            /// <summary>
            /// Market Data Request Msg
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
                Size = 96;
                Type = Protocol.MessageType.MarketDataRequest;

                // Payload
                RequestAction = action;
                SymbolId = symbolId;
                Symbol = symbol;
                Exchange = exchange;
                NumLevels = numLevels;
            }

            /// <summary>
            /// Binary Formatted Msg
            /// </summary>
            /// <returns></returns>
            public byte[] Binary()
            {
                var payload = Utils.Combine(BitConverter.GetBytes((int)RequestAction),
                                            BitConverter.GetBytes(SymbolId),
                                            Utils.AsPaddedBytes(Symbol, Protocol.SymbolLength),
                                            Utils.AsPaddedBytes(Exchange, Protocol.ExchangeLength),
                                            BitConverter.GetBytes(NumLevels));

                var bytes = Utils.Combine(GetHeader(), payload);

                return bytes;
            }

        }
    }
}
