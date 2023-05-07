using QuikSharp.DataStructures;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Extensions
{
    public static class SecurityInfoExtensions
    {
        public static StockTicker ToStockTicker(this SecurityInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            return new StockTicker(info.ClassCode, info.Name, info.ShortName, StockExchange.Moex,
                InstrumentType.Stock, new Currency(info.FaceUnit), new LotFilter(info.LotSize),
                            new PriceFilter(Convert.ToDecimal(info.MinPriceStep)));
        }
    }
}
