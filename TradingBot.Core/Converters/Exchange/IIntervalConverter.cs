using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.Core.Converters.Exchange
{
    public interface IIntervalConverter<TInterval> : IConverter<Interval, TInterval>
    {
        TInterval OneDay { get; }

        TInterval OneHour { get; }

        TInterval OneMinute { get; }

        TInterval FiveMinutes { get; }
    }
}
