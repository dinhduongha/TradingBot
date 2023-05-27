using Okex.Net.Enums;
using Okex.Net.Objects.Market;
using Okex.Net.Objects.Public;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.CryptoExchanges.Okx
{
    public interface IOkxConverter : IExchangeConverter<OkexCandlestick, OkexInstrument, OkexPeriod>
    {

    }
}
