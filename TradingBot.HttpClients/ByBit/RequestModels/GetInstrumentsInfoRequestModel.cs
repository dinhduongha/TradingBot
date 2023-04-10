using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit.RequestModels
{
    public class GetInstrumentsInfoRequestModel
    {
        public int Limit { get; }

        public string Cursor { get; }

        public string Category { get; }

        public GetInstrumentsInfoRequestModel(Category category, int limit = 1000, string cursor = "")
        {
            if (limit <= 0 || limit > 1000) throw new ArgumentOutOfRangeException(nameof(limit));
            if (cursor == null) throw new ArgumentNullException(nameof(cursor));

            Limit = limit;
            Cursor = cursor;
            Category = ByBitDictionaries.Categories[category];
        }
    }
}
