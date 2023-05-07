namespace TradingBot.Core.Domain
{
    public class PriceFilter
    {
        public decimal? MinStep { get; }

        public PriceFilter(decimal? minStep)
        {
            if (minStep != null && minStep <= 0) throw new ArgumentOutOfRangeException(nameof(minStep));

            MinStep = minStep;
        }
    }
}
