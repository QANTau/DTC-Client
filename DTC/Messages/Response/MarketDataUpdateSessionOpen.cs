using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Update Session Open Message
        /// </summary>
        public class MarketDataUpdateSessionOpen : JsonHeader
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
        /// Market Data Update Session Open Message
        /// </summary>
        public class MarketDataUpdateSessionOpenInt : JsonHeader
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
