using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Update Session Message
        /// </summary>
        public class MarketDataUpdateSessionNumTrades : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //int32_t NumTrades;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public uint SymbolID { get; set; }
            public int NumTrades { get; set; }
            public int TradingSessionDate { get; set; }

        }

    }
}
