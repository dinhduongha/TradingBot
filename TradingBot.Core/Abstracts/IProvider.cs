namespace TradingBot.Core.Abstracts
{
    public interface IProvider<TResult>
    {
        Task<TResult> ProvideAsync();
    }

    public interface IProviderLazy<TResult>
    {
        IAsyncEnumerable<TResult> ProvideLazyAsync();
    }
}
