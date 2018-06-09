using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <inheritdoc />
        /// <summary>
        /// Market Data Snapshot Message
        /// </summary>
        public class MarketDataSnapshot : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //double SessionSettlementPrice;
            //double SessionOpenPrice;
            //double SessionHighPrice;
            //double SessionLowPrice;
            //double SessionVolume;
            //uint32_t SessionNumTrades;
            //uint32_t OpenInterest;
            //double BidPrice;
            //double AskPrice;
            //double AskQuantity;
            //double BidQuantity;
            //double LastTradePrice;
            //double LastTradeVolume;
            //t_DateTimeWithMilliseconds LastTradeDateTime;
            //t_DateTimeWithMilliseconds BidAskDateTime;
            //t_DateTime4Byte SessionSettlementDateTime;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public int SymbolId { get; set; }
            public double SessionSettlementPrice { get; set; }
            public double SessionOpenPrice { get; set; }
            public double SessionHighPrice { get; set; }
            public double SessionLowPrice { get; set; }
            public double SessionVolume { get; set; }
            public int SessionNumTrades { get; set; }
            public int OpenInterest { get; set; }
            public double BidPrice { get; set; }
            public double AskPrice { get; set; }
            public double AskQuantity { get; set; }
            public double BidQuantity { get; set; }
            public double LastTradePrice { get; set; }
            public double LastTradeVolume { get; set; }
            public double LastTradeDateTime { get; set; }
            public double BidAskDateTime { get; set; }
            public int SessionSettlementDateTime { get; set; }
            public int TradingSessionDate { get; set; }

        }
    }
}
