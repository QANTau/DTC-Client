using System;

namespace QANT.DTC
{
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

            public int SymbolId { get; set; }
            public double Price { get; set; }
            public int TradingSessionDate { get; set; }

            public DateTime DateTime()
            {
                return Utils.WindowsDateTime(TradingSessionDate);
            }

        }
    }
}
