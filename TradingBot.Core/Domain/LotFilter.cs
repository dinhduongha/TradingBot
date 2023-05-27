namespace TradingBot.Core.Domain
{
    public class LotFilter
    {
        public decimal Size { get; }

        public LotFilter(decimal size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));

            Size = size;
        }
    }
}
