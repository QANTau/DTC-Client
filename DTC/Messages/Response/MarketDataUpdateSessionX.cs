using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Market Data Update Session Msg
        /// </summary>
        public class MarketDataUpdateSessionX : Header
        {

            #region C++ Struct
            //uint32_t SymbolID;
            //double Price;
            //t_DateTime4Byte TradingSessionDate;
            #endregion

            public int SymbolId { get; }                        //  4 Bytes - Pos 0
            public double Price { get; }                        //  8 Bytes - Pos 4
            public double TradingSessionDate { get; }           //  4 Bytes - Pos 12

            /// <summary>
            /// Market Data Update Session Msg
            /// </summary>
            public MarketDataUpdateSessionX(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                SymbolId = BitConverter.ToInt32(payload, 0);

                Price = BitConverter.ToDouble(payload, 4);

                TradingSessionDate = BitConverter.ToDouble(payload, 12);
            }

        }
    }
}
