using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Last Trade Snapshot Message
        /// </summary>
        public class MarketDataUpdateLastTradeSnapshot : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //double LastTradePrice;
            //double LastTradeVolume;
            //t_DateTimeWithMilliseconds LastTradeDateTime;
            #endregion

            public int SymbolID { get; set; }
            public double LastTradePrice { get; set; }
            public double LastTradeVolume { get; set; }
            public double LastTradeDateTime { get; set; }

        }
    }
}
