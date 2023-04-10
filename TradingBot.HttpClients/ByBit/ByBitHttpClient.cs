using TradingBot.Core.Configuration;
using TradingBot.Core.Cryptography;
using TradingBot.Core.Cryptography.Signature;
using TradingBot.HttpClients.Core;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.ByBit
{
    public class ByBitHttpClient : BaseHttpClient
    {
        private readonly IApiKey _apiKey;
        private readonly ISigner _signer;

        protected override IHttpRequestHandler HttpRequestHandler => new ByBitHttpRequestHandler();

        public ByBitHttpClient(IApiKey apiKey, string path) : base($"{ByBitRoutes.Protocol}://{ByBitRoutes.Domain}/v5/" +
            $"{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            _apiKey = apiKey;
            _signer = new HmacSha256();
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

            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            var recvWindow = "1000000";

            var text = $"{timestamp}{_apiKey.Key}{recvWindow}{uri.Substring(uri.IndexOf("?") + 1)}";
            var signature = _signer.Sign(text, _apiKey.Secret);

            var headers = new Dictionary<string, string>()
            {
                { "X-BAPI-SIGN", signature },
                { "X-BAPI-API-KEY", _apiKey.Key },
                { "X-BAPI-TIMESTAMP", timestamp },
                { "X-BAPI-RECV-WINDOW", recvWindow }
            };

            OverrideHeaders(headers);
        }
    }
}
