using Binance.Net.Enums;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.CryptoExchanges.Binance.Converters
{
    public class BinanceIntervalConverter : BaseIntervalConverter<KlineInterval>
    {
        public override KlineInterval OneDay => KlineInterval.OneDay;

        public override KlineInterval OneHour => KlineInterval.OneHour;

        public override KlineInterval OneMinute => KlineInterval.OneMinute;

        public override KlineInterval FiveMinutes => KlineInterval.FiveMinutes;
    }
}
