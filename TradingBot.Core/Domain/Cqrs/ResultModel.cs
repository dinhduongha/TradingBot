namespace TradingBot.Core.Domain.Cqrs
{
    public class ResultModel<TResult>
    {
        public TResult Data { get; }

        public bool IsError { get; }

        public string ErrorMessage { get; }

        public ResultModel(TResult data) : this(data, false, string.Empty)
        {

        }

        public ResultModel(TResult data, bool isError) : this(data, isError, string.Empty)
        {

        }

        public ResultModel(TResult data, bool isError, string errorMessage)
        {
            Data = data;
            IsError = isError;
            ErrorMessage = errorMessage;
        }
    }
}
