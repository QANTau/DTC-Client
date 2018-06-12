using System;
using System.Diagnostics.CodeAnalysis;

namespace QANT.DTC
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Messages
    {
        /// <inheritdoc />
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
            public uint SymbolID { get; set; }

            public DateTime TimeStamp()
            {
                return Utils.WindowsDateTime(DateTime);
            }

        }

        /// <inheritdoc />
        /// <summary>
        /// Market Data Update Bid/Ask Message
        /// </summary>
        public class MarketDataUpdateBidAsk : JsonHeader
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //double BidPrice;
            //float BidQuantity;
            //double AskPrice;
            //float AskQuantity;
            //t_DateTime4Byte DateTime;
            #endregion

            public uint SymbolID { get; set; }
            public double BidPrice { get; set; }
            public float BidQuantity { get; set; }
            public double AskPrice { get; set; }
            public float AskQuantity { get; set; }
            public int DateTime { get; set; }

            public MarketDataUpdateBidAsk()
            { }

            public MarketDataUpdateBidAsk(MarketDataUpdateBidAskCompact message)
            {
                SymbolID = message.SymbolID;
                BidPrice = message.BidPrice;
                BidQuantity = message.BidQuantity;
                AskPrice = message.AskPrice;
                AskQuantity = message.AskQuantity;
                DateTime = message.DateTime;
            }

            public DateTime TimeStamp()
            {
                return Utils.WindowsDateTime(DateTime);
            }

        }
    }
}
