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
        public class MarketDataUpdateSessionVolume : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //double Volume;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public uint SymbolID { get; set; }
            public double Volume { get; set; }
            public int TradingSessionDate { get; set; }

        }

    }
}
