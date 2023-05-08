namespace TradingBot.Core.Abstracts
{
    public interface IProvider<TResult>
    {
        Task<TResult> ProvideAsync();
    }
}
