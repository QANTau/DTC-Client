﻿using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Update Session Message
        /// </summary>
        public class MarketDataUpdateSessionLow : JsonHeader
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
        /// Market Data Update Session (Integer) Message
        /// </summary>
        public class MarketDataUpdateSessionLowInt : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //int32_t Price;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public uint SymbolID { get; set; }
            public int Price { get; set; }
            public int TradingSessionDate { get; set; }

        }
    }
}
