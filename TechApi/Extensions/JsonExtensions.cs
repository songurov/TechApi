using TechApi.Data;
using Newtonsoft.Json;

namespace TechApi.Extensions
{
    public static class JsonExtensions
    {
        public static T GetObject<T>(this SqlWrapper sqlWrapper)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(sqlWrapper.DATA_TABLE));
        }
    }
}