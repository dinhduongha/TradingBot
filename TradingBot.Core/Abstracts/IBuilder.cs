namespace TradingBot.Core.Abstracts
{
    public interface IBuilder<TOutput>
    {
        TOutput Build();
    }
}
