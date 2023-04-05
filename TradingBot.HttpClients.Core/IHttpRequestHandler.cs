using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.Core
{
    public interface IHttpRequestHandler
    {
        IHttpResponseMaper Maper { get; }

        IHttpResponseReader Reader { get; }

        Task<ResponseModel<TResult>> HandleAsync<TResult>(Func<Task<HttpResponseMessage>> request);
    }
}
