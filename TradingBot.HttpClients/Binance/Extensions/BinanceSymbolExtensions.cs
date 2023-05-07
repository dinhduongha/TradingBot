using Binance.Net.Objects.Models.Spot;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Binance.Extensions
{
    public static class BinanceSymbolExtensions
    {
        public static StockTicker ToStockTicker(this BinanceSymbol symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            return new StockTicker(symbol.Name, $"BINANCE {symbol.BaseAsset}/{symbol.QuoteAsset}",
                symbol.BaseAsset, StockExchange.Binance, InstrumentType.Spot, new Currency(symbol.QuoteAsset),
                    new LotFilter(symbol.LotSizeFilter?.StepSize), new PriceFilter(symbol?.PriceFilter?.TickSize));
        }
    }
}
