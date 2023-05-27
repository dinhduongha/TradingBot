namespace TradingBot.Core.Abstracts
{
    public interface IConverter<TInput, TOutput>
    {
        TOutput Convert(TInput input);
    }
}
