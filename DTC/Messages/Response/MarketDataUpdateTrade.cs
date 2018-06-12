
using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Update Trade (Compact) Message
        /// </summary>
        public class MarketDataUpdateTradeCompact : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //AtBidOrAskEnum AtBidOrAsk;
            //double Price;
            //double Volume;
            //t_DateTimeWithMilliseconds DateTime;
            #endregion

            public uint SymbolID { get; set; }
            public Protocol.AtBidOrAsk AtBidOrAskEnum { get; set; }
            public double Price { get; set; }
            public double Volume { get; set; }
            public double DateTime { get; set; }

        }
    }
}
