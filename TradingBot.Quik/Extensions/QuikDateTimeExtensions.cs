using QuikSharp.DataStructures;

namespace TradingBot.Quik.Extensions
{
    public static class QuikDateTimeExtensions
    {
        public static DateTime ToDateTime(this QuikDateTime dateTime) 
        {
            if (dateTime == null) throw new ArgumentNullException(nameof(dateTime));

            return new DateTime(dateTime.year, dateTime.month, dateTime.day, dateTime.hour, dateTime.min, 
                dateTime.sec, dateTime.ms, dateTime.mcs);
        }
    }
}
