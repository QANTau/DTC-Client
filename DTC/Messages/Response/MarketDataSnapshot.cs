using System;

namespace QANT.DTC
{
    public partial class Messages
    {
        /// <summary>
        /// Market Data Snapshot Msg
        /// </summary>
        public class MarketDataSnapshot : Header
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

            public int SymbolId { get; }                        //  4 Bytes - Pos 0
            public double SessionSettlementPrice { get; }       //  8 Bytes - Pos 4
            public double SessionOpenPrice { get; }             //  8 Bytes - Pos 12
            public double SessionHighPrice { get; }             //  8 Bytes - Pos 20
            public double SessionLowPrice { get; }              //  8 Bytes - Pos 28
            public double SessionVolume { get; }                //  8 Bytes - Pos 36
            public int SessionNumTrades { get; }                //  4 Bytes - Pos 44
            public int OpenInterest { get; }                    //  4 Bytes - Pos 48
            public double BidPrice { get; }                     //  8 Bytes - Pos 52
            public double AskPrice { get; }                     //  8 Bytes - Pos 60
            public double AskQuantity { get; }                  //  8 Bytes - Pos 68
            public double BidQuantity { get; }                  //  8 Bytes - Pos 76
            public double LastTradePrice { get; }               //  8 Bytes - Pos 84
            public double LastTradeVolume { get; }              //  8 Bytes - Pos 92
            public double LastTradeDateTime { get; }            //  8 Bytes - Pos 100
            public double BidAskDateTime { get; }               //  8 Bytes - Pos 108
            public int SessionSettlementDateTime { get; }       //  4 Bytes - Pos 116
            public int TradingSessionDate { get; }              //  4 Bytes - Pos 120

            /// <summary>
            /// Market Data Snapshot Msg
            /// </summary>
            public MarketDataSnapshot(Header header, byte[] payload)
            {
                // Header
                Size = header.Size;
                Type = header.Type;

                // Payload
                SymbolId = BitConverter.ToInt32(payload, 0);

                SessionSettlementPrice = BitConverter.ToDouble(payload, 4);

                SessionOpenPrice = BitConverter.ToDouble(payload, 12);

                SessionHighPrice = BitConverter.ToDouble(payload, 20);

                SessionLowPrice = BitConverter.ToDouble(payload, 28);

                SessionVolume = BitConverter.ToDouble(payload, 36);

                SessionNumTrades = BitConverter.ToInt32(payload, 44);

                OpenInterest = BitConverter.ToInt32(payload, 48);

                BidPrice = BitConverter.ToDouble(payload, 52);

                AskPrice = BitConverter.ToDouble(payload, 60);

                AskQuantity = BitConverter.ToDouble(payload, 68);

                BidQuantity = BitConverter.ToDouble(payload, 76);

                LastTradePrice = BitConverter.ToDouble(payload, 84);

                LastTradeVolume = BitConverter.ToDouble(payload, 92);

                LastTradeDateTime = BitConverter.ToDouble(payload, 100);

                BidAskDateTime = BitConverter.ToDouble(payload, 108);

                SessionSettlementDateTime = BitConverter.ToInt32(payload, 116);

                TradingSessionDate = BitConverter.ToInt32(payload, 120);

            }

        }
    }
}
