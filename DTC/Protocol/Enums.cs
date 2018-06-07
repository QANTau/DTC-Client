

namespace QANT.DTC
{
    public partial class Protocol
    {

        public enum Encoding
        {
            BinaryEncoding = 0,
            BinaryWithVariableLengthStrings = 1,
            JsonEncoding = 2,
            JsonCompactEncoding = 3,
            ProtocolBuffers = 4
        }

        public enum LogonStatus
        {
            LogonSuccess = 1,
            LogonError = 2,
            LogonErrorNoReconnect = 3,
            LogonReconnectNewAddress = 4
        }

        public enum MessageSupported
        {
            MessageUnsupported = 0,
            MessageSupported = 1
        }

        public enum TradeMode
        {
            TradeModeUnset = 0,
            TradeModeDemo = 1,
            TradeModeSimulated = 2,
            TradeModeLive = 3
        }

        public enum RequestAction
        {
            Subscribe = 1,
            Unsubscribe = 2,
            Snapshot = 3
        }

        public enum OrderStatus
        {
            OrderStatusUnspecified = 0,
            OrderStatusOrderSent = 1,
            OrderStatusPendingOpen = 2,
            OrderStatusPendingChild = 3,
            OrderStatusOpen = 4,
            OrderStatusPendingCancelReplace = 5,
            OrderStatusPendingCancel = 6,
            OrderStatusFilled = 7,
            OrderStatusCanceled = 8,
            OrderStatusRejected = 9,
            OrderStatusPartiallyFilled = 10
        }

        public enum OrderUpdateReason
        {
            OrderUpdateReasonUnset = 0,
            OpenOrdersRequestResponse = 1,
            NewOrderAccepted = 2,
            GeneralOrderUpdate = 3,
            OrderFilled = 4,
            OrderFilledPartially = 5,
            OrderCanceled = 6,
            OrderCancelReplaceComplete = 7,
            NewOrderRejected = 8,
            OrderCancelRejected = 9,
            OrderCancelReplaceRejected = 10
        }

        public enum AtBidOrAsk : ushort
        {
            BidAskUnset = 0,
            AtBid = 1,
            AtAsk = 2
        }

        public enum MarketDepthUpdateType : byte
        {
            DepthUnset = 0,
            MarketDepthInsertUpdateLevel = 1,   // Insert or update depth at the given price level
            MarketDepthDeleteLevel = 2           // Delete depth at the given price level
        }

        public enum OrderType
        {
            OrderTypeUnset = 0,
            OrderTypeMarket = 1,
            OrderTypeLimit = 2,
            OrderTypeStop = 3,
            OrderTypeStopLimit = 4,
            OrderTypeMarketIfTouched = 5
        }

        public enum TimeInForce
        {
            TifUnset = 0,
            TifDay = 1,
            TifGoodTillCanceled = 2,
            TifGoodTillDateTime = 3,
            TifImmediateOrCancel = 4,
            TifAllOrNone = 5,
            TifFillOrKill = 6
        }

        public enum BuySell
        {
            BuySellUnset = 0,
            Buy = 1,
            Sell = 2
        }

        public enum OpenCloseTrade
        {
            TradeUnset = 0,
            TradeOpen = 1,
            TradeClose = 2
        }

        public enum PartialFillHandling : byte
        {
            PartialFillUnset = 0,
            PartialFillHandlingReduceQuantity = 1,
            PartialFillHandlingImmediateCancel = 2
        }

        public enum MarketDataFeedStatus
        {
            MarketDataFeedStatusUnset = 0,
            MarketDataFeedUnavailable = 1,
            MarketDataFeedAvailable = 2
        }

        public enum PriceDisplayFormat
        {
            PriceDisplayFormatUnset = -1,
            //The following formats indicate the number of decimal places to be displayed
            PriceDisplayFormatDecimal0 = 0,
            PriceDisplayFormatDecimal1 = 1,
            PriceDisplayFormatDecimal2 = 2,
            PriceDisplayFormatDecimal3 = 3,
            PriceDisplayFormatDecimal4 = 4,
            PriceDisplayFormatDecimal5 = 5,
            PriceDisplayFormatDecimal6 = 6,
            PriceDisplayFormatDecimal7 = 7,
            PriceDisplayFormatDecimal8 = 8,
            PriceDisplayFormatDecimal9 = 9,
            //The following formats are fractional formats
            PriceDisplayFormatDenominator256 = 356,
            PriceDisplayFormatDenominator128 = 228,
            PriceDisplayFormatDenominator64 = 164,
            PriceDisplayFormatDenominator32Quarters = 136,
            PriceDisplayFormatDenominator32Halves = 134,
            PriceDisplayFormatDenominator32 = 132,
            PriceDisplayFormatDenominator16 = 116,
            PriceDisplayFormatDenominator8 = 108,
            PriceDisplayFormatDenominator4 = 104,
            PriceDisplayFormatDenominator2 = 102
        }

        public enum SecurityType
        {
            SecurityTypeUnset = 0,
            SecurityTypeFutures = 1,
            SecurityTypeStock = 2,
            SecurityTypeForex = 3, // Bitcoins also go into this category
            SecurityTypeIndex = 4,
            SecurityTypeFuturesStrategy = 5,
            SecurityTypeFuturesOption = 7,
            SecurityTypeStockOption = 6,
            SecurityTypeIndexOption = 8,
            SecurityTypeBond = 9,
            SecurityTypeMutualFund = 10
        }

        /// <summary>
        /// Returns Security Type as a Generic (and portable) String
        /// </summary>
        /// <param name="securityType"></param>
        /// <returns></returns>
        public string GetSecurityType(SecurityType securityType)
        {
            switch (securityType)
            {
                case SecurityType.SecurityTypeFutures:
                    return "Futures";
                case SecurityType.SecurityTypeStock:
                    return "Stock";
                case SecurityType.SecurityTypeForex:
                    return "Forex";
                case SecurityType.SecurityTypeIndex:
                    return "Index";
                case SecurityType.SecurityTypeFuturesStrategy:
                    return "Futures Strategy";
                case SecurityType.SecurityTypeFuturesOption:
                    return "Futures Option";
                case SecurityType.SecurityTypeStockOption:
                    return "Stock Option";
                case SecurityType.SecurityTypeIndexOption:
                    return "Index Option";
                case SecurityType.SecurityTypeBond:
                    return "Bond";
                case SecurityType.SecurityTypeMutualFund:
                    return "Mutual Fund";
                default:
                    return "Unknown";
            }
        }

        public enum PutOrCall : byte
        {
            PcUnset = 0,
            PcCall = 1,
            PcPut = 2
        }

        public enum SearchType
        {
            SearchTypeUnset = 0,
            SearchTypeBySymbol = 1,
            SearchTypeByDescription = 2
        }

        public enum HistoricalDataInterval
        {
            IntervalTick = 0,
            Interval1Second = 1,
            Interval2Seconds = 2,
            Interval4Seconds = 4,
            Interval5Seconds = 5,
            Interval10Seconds = 10,
            Interval30Seconds = 30,
            Interval1Minute = 60,
            Interval1Day = 86400,
            Interval1Week = 604800
        }

        public enum HistoricalPriceDataRejectReasonCode : short
        {
            HpdrUnset = 0,
            HpdrUnableToServeDataRetryInSpecifiedSeconds = 1,
            HpdrUnableToServeDataDoNotRetry = 2,
            HpdrDataRequestOutsideBoundsOfAvailableData = 3,
            HpdrGeneralRejectError = 4
        }

        public enum MessageType : ushort
        {
            LogonRequest = 1,
            LogonResponse = 2,
            Heartbeat = 3,
            Logoff = 5,
            EncodingRequest = 6,
            EncodingResponse = 7,
            MarketDataRequest = 101,
            MarketDataReject = 103,
            MarketDataSnapshot = 104,
            MarketDataSnapshotInt = 125,
            MarketDataUpdateTrade = 107,
            MarketDataUpdateTradeCompact = 112,
            MarketDataUpdateTradeInt = 126,
            MarketDataUpdateLastTradeSnapshot = 134,
            MarketDataUpdateBidAsk = 108,
            MarketDataUpdateBidAskCompact = 117,
            MarketDataUpdateBidAskInt = 127,
            MarketDataUpdateSessionOpen = 120,
            MarketDataUpdateSessionOpenInt = 128,
            MarketDataUpdateSessionHigh = 114,
            MarketDataUpdateSessionHighInt = 129,
            MarketDataUpdateSessionLow = 115,
            MarketDataUpdateSessionLowInt = 130,
            MarketDataUpdateSessionVolume = 113,
            MarketDataUpdateOpenInterest = 124,
            MarketDataUpdateSessionSettlement = 119,
            MarketDataUpdateSessionSettlementInt = 131,
            MarketDataUpdateSessionNumTrades = 135,
            MarketDataUpdateTradingSessionDate = 136,
            MarketDepthRequest = 102,
            MarketDepthReject = 121,
            MarketDepthSnapshotLevel = 122,
            MarketDepthSnapshotLevelInt = 132,
            MarketDepthUpdateLevel = 106,
            MarketDepthUpdateLevelCompact = 118,
            MarketDepthUpdateLevelInt = 133,
            MarketDepthFullUpdate10 = 123,
            MarketDepthFullUpdate20 = 105,
            MarketDataFeedStatus = 100,
            MarketDataFeedSymbolStatus = 116,
            SubmitNewSingleOrder = 208,
            SubmitNewSingleOrderInt = 206,
            SubmitNewOcoOrder = 201,
            SubmitNewOcoOrderInt = 207,
            CancelOrder = 203,
            CancelReplaceOrder = 204,
            CancelReplaceOrderInt = 205,
            OpenOrdersRequest = 300,
            OpenOrdersReject = 302,
            OrderUpdate = 301,
            HistoricalOrderFillsRequest = 303,
            HistoricalOrderFillsReject = 308,
            HistoricalOrderFillResponse = 304,
            CurrentPositionsRequest = 305,
            CurrentPositionsReject = 307,
            PositionUpdate = 306,
            TradeAccountsRequest = 400,
            TradeAccountResponse = 401,
            ExchangeListRequest = 500,
            ExchangeListResponse = 501,
            SymbolsForExchangeRequest = 502,
            UnderlyingSymbolsForExchangeRequest = 503,
            SymbolsForUnderlyingRequest = 504,
            SecurityDefinitionForSymbolRequest = 506,
            SecurityDefinitionResponse = 507,
            SymbolSearchRequest = 508,
            SecurityDefinitionReject = 509,
            AccountBalanceRequest = 601,
            AccountBalanceReject = 602,
            AccountBalanceUpdate = 600,
            UserMessage = 700,
            GeneralLogMessage = 701,
            HistoricalPriceDataRequest = 800,
            HistoricalPriceDataResponseHeader = 801,
            HistoricalPriceDataReject = 802,
            HistoricalPriceDataRecordResponse = 803,
            HistoricalPriceDataTickRecordResponse = 804,
            HistoricalPriceDataRecordResponseInt = 805,
            HistoricalPriceDataTickRecordResponseInt = 806,
            HistoricalPriceDataResponseTrailer = 807
        }
    }
}
