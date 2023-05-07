using Bybit.Net.Objects.Models.V5;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit.Extensions
{
    public static class BybitSpotSymbolExtensions
    {
        public static StockTicker ToStockTicker(this BybitSpotSymbol symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            return new StockTicker(symbol.Name, $"BYBIT {symbol.BaseAsset}/{symbol.QuoteAsset}",
                symbol.BaseAsset, StockExchange.ByBit, InstrumentType.Spot, new Currency(symbol.QuoteAsset),
                    new LotFilter(symbol.LotSizeFilter?.BasePrecision), new PriceFilter(symbol?.PriceFilter?.TickSize));
        }
    }
}
