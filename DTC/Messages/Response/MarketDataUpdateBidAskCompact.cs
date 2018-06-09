using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Market Data Update Bid/Ask (Compact) Message
        /// </summary>
        public class MarketDataUpdateBidAskCompact : JsonHeader
        {

            #region C++ Struct
            //float BidPrice;
            //float BidQuantity;
            //float AskPrice;
            //float AskQuantity;
            //t_DateTime4Byte DateTime;
            //uint32_t SymbolID;
            #endregion

            public float BidPrice { get; set; }
            public float BidQuantity { get; set; }
            public float AskPrice { get; set; }
            public float AskQuantity { get; set; }
            public int DateTime { get; set; }
            public int SymbolId { get; set; }

        }
    }
}
