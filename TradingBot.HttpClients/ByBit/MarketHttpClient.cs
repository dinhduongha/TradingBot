using TradingBot.Core.Configuration;
using TradingBot.Core.Extensions;
using TradingBot.HttpClients.ByBit.RequestModels;
using TradingBot.HttpClients.ByBit.ResponseModels;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.ByBit
{
    public class MarketHttpClient : ByBitHttpClient
    {
        public MarketHttpClient(IApiKey apiKey) : base(apiKey, ByBitRoutes.MarketPath + "/")
        {

        }

        public async Task<ResponseModel<GetKlineResponseModel>> GetKlineAsync(GetKlineRequestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await GetAsync<GetKlineResponseModel>(ByBitRoutes.MarketGetKlineQuery.Inject(model));
        }

        public async Task<ResponseModel<GetInstrumentsInfoResponseModel>> GetInstrumentsInfoAsync(
            GetInstrumentsInfoRequestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await GetAsync<GetInstrumentsInfoResponseModel>(ByBitRoutes.MarketGetInstrumentsInformationQuery
                .Inject(model));
        }

        public async Task<ResponseModel<GetOrderbookResponseModel>> GetOrderbookAsync(GetOrderbookRequestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await GetAsync<GetOrderbookResponseModel>(ByBitRoutes.MarketGetOrderbookQuery
                .Inject(model));
        }

        public async Task<ResponseModel<GetTickersResponseModel>> GetTickersAsync(GetTickersRequestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await GetAsync<GetTickersResponseModel>(ByBitRoutes.MarketGetTickersQuery
                .Inject(model));
        }
    }
}
