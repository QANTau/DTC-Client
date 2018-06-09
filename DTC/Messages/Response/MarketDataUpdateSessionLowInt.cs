using System;

namespace QANT.DTC
{
    public partial class Messages
    {
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

            public int SymbolId { get; set; }
            public int Price { get; set; }
            public int TradingSessionDate { get; set; }

            public DateTime DateTime()
            {
                return Utils.WindowsDateTime(TradingSessionDate);
            }

        }
    }
}
