using Bybit.Net.Objects.Models.V5;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.ByBit.Converters
{
    public class ByBitTickerConverter : ITickerConverter<BybitSpotSymbol>
    {
        public StockTicker Convert(BybitSpotSymbol input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.Name, $"BYBIT {input.BaseAsset}/{input.QuoteAsset}",
                input.BaseAsset, StockExchange.ByBit, InstrumentType.Spot, new Currency(input.QuoteAsset),
                        new LotFilter(input.LotSizeFilter?.BasePrecision), new PriceFilter(input?.PriceFilter?.TickSize));
        }
    }
}
