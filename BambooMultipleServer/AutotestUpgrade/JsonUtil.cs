using Newtonsoft.Json;
using System;
namespace winformUI.Common
{
    public static class JsonUtil
    {
        public static string ToJSONStr(this object o)
        {
            if (o == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(o);
        }

        public static T FromJSONClass<T>(this string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return default(T);
                }
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
