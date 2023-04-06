using System.Security.Cryptography;
using System.Text;
using TradingBot.HttpClients.Core;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.ByBit
{
    public class ByBitHttpClient : BaseHttpClient
    {
        protected override IHttpRequestHandler HttpRequestHandler => new ByBitHttpRequestHandler();

        public ByBitHttpClient(string path) : base($"{ByBitRoutes.Protocol}://{ByBitRoutes.Domain}/v5/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
        }

        protected override async Task<ResponseModel<TResult>> GetAsync<TResult>(string uri, 
            CancellationToken cancellationToken = default)
        {
            UseAuthenticationHeaders(uri);

            return await base.GetAsync<TResult>(uri, cancellationToken);
        }

        protected override async Task<ResponseModel<TResult>> PostAsync<TResult>(string uri, object content, 
            CancellationToken cancellationToken = default)
        {
            UseAuthenticationHeaders(uri);

            return await base.PostAsync<TResult>(uri, content, cancellationToken);
        }

        protected override async Task<ResponseModel<TResult>> PutAsync<TResult>(string uri, object content, 
            CancellationToken cancellationToken = default)
        {
            UseAuthenticationHeaders(uri);

            return await base.PutAsync<TResult>(uri, content, cancellationToken);
        }

        protected override async Task<ResponseModel<TResult>> DeleteAsync<TResult>(string uri, 
            CancellationToken cancellationToken = default)
        {
            UseAuthenticationHeaders(uri);

            return await base.DeleteAsync<TResult>(uri, cancellationToken);
        }

        private void UseAuthenticationHeaders(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            var apiKey = Environment.GetEnvironmentVariable("BYBIT_API_KEY") ?? "";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var recvWindow = 5000.ToString();

            var headers = new Dictionary<string, string>()
            {
                { "X-BAPI-API-KEY", apiKey },
                { "X-BAPI-TIMESTAMP", timestamp },
                { "X-BAPI-RECV-WINDOW", recvWindow },
                { "X-BAPI-SIGN", SHA256.HashData(Encoding.UTF8.GetBytes($"{timestamp}{apiKey}" +
                    $"{recvWindow}{uri.Substring(uri.IndexOf("?") + 1)}"))?.ToString() ?? "" }
            };

            OverrideHeaders(headers);
        }
    }
}
