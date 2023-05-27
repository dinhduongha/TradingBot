using Okex.Net.Enums;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.CryptoExchanges.Okx.Converters
{
    public class OkxIntervalConverter : BaseIntervalConverter<OkexPeriod>
    {
        public override OkexPeriod OneDay => OkexPeriod.OneDay;

        public override OkexPeriod OneHour => OkexPeriod.OneHour;

        public override OkexPeriod OneMinute => OkexPeriod.OneMinute;

        public override OkexPeriod FiveMinutes => OkexPeriod.FiveMinutes;
    }
}
