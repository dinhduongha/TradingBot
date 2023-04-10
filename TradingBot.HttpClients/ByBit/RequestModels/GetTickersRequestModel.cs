using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit.RequestModels
{
    public class GetTickersRequestModel
    {
        public string Category { get; }

        public GetTickersRequestModel(Category category)
        {
            Category = ByBitDictionaries.Categories[category];
        }
    }
}
