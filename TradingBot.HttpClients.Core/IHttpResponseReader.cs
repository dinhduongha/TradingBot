namespace TradingBot.HttpClients.Core
{
    public interface IHttpResponseReader
    {
        Task<string> ReadAsync(HttpResponseMessage response);
    }
}
