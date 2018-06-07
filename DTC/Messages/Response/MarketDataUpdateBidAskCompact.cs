using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Market Data Update Bid/Ask (Compact) Msg
        /// </summary>
        public class MarketDataUpdateBidAskCompact : Header
        {

            #region C++ Struct
            //float BidPrice;
            //float BidQuantity;
            //float AskPrice;
            //float AskQuantity;
            //t_DateTime4Byte DateTime;
            //uint32_t SymbolID;
            #endregion

            public float BidPrice { get; }                      //  4 Bytes - Pos 0
            public float BidQuantity { get; }                   //  4 Bytes - Pos 4
            public float AskPrice { get; }                      //  4 Bytes - Pos 8
            public float AskQuantity { get; }                   //  4 Bytes - Pos 12
            public int BidAskDateTime { get; }                  //  4 Bytes - Pos 16
            public int SymbolId { get; }                        //  4 Bytes - Pos 20

            /// <summary>
            /// DateTime in UTC
            /// </summary>
            public DateTime DateTime { get; }

            /// <summary>
            /// Market Data Update Bid/Ask (Compact) Msg
            /// </summary>
            public MarketDataUpdateBidAskCompact(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                BidPrice = BitConverter.ToSingle(payload, 0);

                BidQuantity = BitConverter.ToSingle(payload, 4);

                AskPrice = BitConverter.ToSingle(payload, 8);

                AskQuantity = BitConverter.ToSingle(payload, 12);

                BidAskDateTime = BitConverter.ToInt32(payload, 4);

                SymbolId = BitConverter.ToInt32(payload, 20);

                /* The DateTime coming in from SC appears to be a static value when
                 * returned via the Compact binary form.  At this stage the Bid/Ask
                 * result is just tagged with the current UTC time which should be
                 * accurate enough at this stage. */
                DateTime = DateTime.UtcNow;
            }

        }
    }
}
