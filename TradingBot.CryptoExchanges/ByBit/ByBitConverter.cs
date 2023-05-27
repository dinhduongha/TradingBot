using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using TradingBot.Core.Converters.Exchange;
using TradingBot.CryptoExchanges.ByBit.Converters;

namespace TradingBot.CryptoExchanges.ByBit
{
    public class ByBitConverter : IByBitConverter
    {
        public IQuoteConverter<BybitKline> Quote => new ByBitQuoteConverter();

        public ITickerConverter<BybitSpotSymbol> Ticker => new ByBitTickerConverter();

        public IIntervalConverter<KlineInterval> Interval => new ByBitIntervalConverter();
    }
}
