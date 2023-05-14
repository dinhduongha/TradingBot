namespace TradingBot.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static decimal? ToDecimal(this double? value) 
        {
            return value != null ? Convert.ToDecimal(value) : null;
        }
    }
}