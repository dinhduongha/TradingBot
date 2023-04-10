using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit.RequestModels
{
    public class GetOrderbookRequestModel
    {
        public int Limit { get; }

        public string Symbol { get; }

        public string Category { get; }

        public GetOrderbookRequestModel(Category category, string symbol, int limit = 50)
        {
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentNullException(nameof(symbol));
            if (limit <= 0 || limit > 200) throw new ArgumentOutOfRangeException(nameof(limit));

            Limit = limit;
            Symbol = symbol;
            Category = ByBitDictionaries.Categories[category];
        }
    }
}
