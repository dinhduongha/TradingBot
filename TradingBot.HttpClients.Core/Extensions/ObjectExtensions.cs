using Newtonsoft.Json;
using System.Text;

namespace TradingBot.HttpClients.Core.Extensions
{
    internal static class ObjectExtensions
    {
        public static StringContent ToStringContent(this object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
