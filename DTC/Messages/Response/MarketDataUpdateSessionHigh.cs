using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Update Session High Message
        /// </summary>
        public class MarketDataUpdateSessionHigh : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //double Price;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public uint SymbolID { get; set; }
            public double Price { get; set; }
            public int TradingSessionDate { get; set; }

        }

        /// <inheritdoc />
        /// <summary>
        /// Market Data Update Session High Message
        /// </summary>
        public class MarketDataUpdateSessionHighInt : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //int Price;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public uint SymbolID { get; set; }
            public int Price { get; set; }
            public int TradingSessionDate { get; set; }

        }
    }
}
