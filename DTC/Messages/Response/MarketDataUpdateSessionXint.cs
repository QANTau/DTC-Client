using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Market Data Update Session (Integer) Msg
        /// </summary>
        public class MarketDataUpdateSessionXint : Header
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //int32_t Price;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public int SymbolId { get; }                        //  4 Bytes - Pos 0
            public int Price { get; }                           //  4 Bytes - Pos 4
            public double TradingSessionDate { get; }           //  4 Bytes - Pos 8

            /// <summary>
            /// Market Data Update Session (Integer) Msg
            /// </summary>
            public MarketDataUpdateSessionXint(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                SymbolId = BitConverter.ToInt32(payload, 0);

                Price = BitConverter.ToInt32(payload, 4);

                TradingSessionDate = BitConverter.ToDouble(payload, 8);
            }

        }
    }
}
