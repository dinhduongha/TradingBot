using Skender.Stock.Indicators;

namespace TradingBot.Core.Domain
{
    public class CustomQuote : IQuote
    {
        public decimal Low { get; }

        public decimal High { get; }

        public decimal Open { get; }

        public decimal Close { get; }

        public decimal Volume { get; }

        public DateTime Date { get; }

        public CustomQuote(decimal low, decimal open, decimal high, decimal close, decimal volume, DateTime date)
        {
            if (volume < 0) throw new ArgumentOutOfRangeException(nameof(volume));

            Low = low;
            Open = open;
            High = high;
            Close = close;
            Volume = volume;
            Date = date;
        }
    }
}
