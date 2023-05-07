namespace TradingBot.Core.Abstracts
{
    public interface IEnumMaper<TInput, TOutput> where TInput : Enum where TOutput : Enum
    {
        TOutput Map(TInput input);
    }
}
