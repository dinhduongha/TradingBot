namespace TradingBot.Core.Abstracts
{
    public interface IProvider<TResult>
    {
        TResult Provide();
    }

    public interface IAsyncLazyProvider<TResult> : IProvider<IAsyncEnumerable<TResult>>
    {

    }
}
