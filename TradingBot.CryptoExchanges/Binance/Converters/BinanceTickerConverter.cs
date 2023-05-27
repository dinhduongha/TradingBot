using Binance.Net.Objects.Models.Spot;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Binance.Converters
{
    public class BinanceTickerConverter : ITickerConverter<BinanceSymbol>
    {
        public StockTicker Convert(BinanceSymbol input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.Name, $"BINANCE {input.BaseAsset}/{input.QuoteAsset}",
                input.BaseAsset, StockExchange.Binance, InstrumentType.Spot, new Currency(input.QuoteAsset),
                    new LotFilter(input.LotSizeFilter?.StepSize), new PriceFilter(input?.PriceFilter?.TickSize));
        }
    }
}
