using Newtonsoft.Json;
using System.Net;

namespace TradingBot.HttpClients.Core.ResponseModels
{
    public class ResponseModel<TResult>
    {
        public bool? IsError { get; }

        public string? Message { get; }

        public HttpStatusCode? Code { get; }

        public TResult? Result { get; }

        public Exception? ResponseException { get; }

        [JsonConstructor]
        public ResponseModel()
        {
            IsError = false;
            Message = null;
            Code = null;
            Result = default(TResult);
            ResponseException = null;
        }

        public ResponseModel(TResult? result, HttpStatusCode? code, string? message, bool? isError = false,
            Exception? exception = null)
        {
            IsError = isError;
            Message = message;
            Code = code;
            Result = result;
            ResponseException = exception;
        }

        public ResponseModel(TResult? result, HttpStatusCode? code, bool? isError = false,
            Exception? exception = null) : this(result, code, code?.ToString(), isError, exception)
        {

        }
    }
}
