using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Market Data Update Trade (Compact) Msg
        /// </summary>
        public class MarketDataUpdateTradeCompact : Header
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //AtBidOrAskEnum AtBidOrAsk;
            //double Price;
            //double Volume;
            //t_DateTimeWithMilliseconds DateTime;
            #endregion

            public int SymbolId { get; }                        //  4 Bytes - Pos 0
            public Protocol.AtBidOrAsk AtBidOrAskEnum { get; }  //  2 Bytes - Pos 4
            public double Price { get; }                        //  8 Bytes - Pos 6
            public double Volume { get; }                       //  8 Bytes - Pos 14
            public double DateTime { get; }                     //  8 Bytes - Pos 22

            /// <summary>
            /// Market Data Update Trade (Compact) Msg
            /// </summary>
            public MarketDataUpdateTradeCompact(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                SymbolId = BitConverter.ToInt32(payload, 0);

                AtBidOrAskEnum = (Protocol.AtBidOrAsk)BitConverter.ToUInt16(payload, 4);

                Price = BitConverter.ToDouble(payload, 6);

                Volume = BitConverter.ToDouble(payload, 14);

                DateTime = BitConverter.ToDouble(payload, 22);
            }

        }
    }
}
