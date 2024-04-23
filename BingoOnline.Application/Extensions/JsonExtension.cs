using System.Text.Json;

namespace BingoOnline.Application.Extensions
{
    public static class JsonExtension
    {
        public static string ToJson<T>(this IList<T> obj) 
        { 
            return JsonSerializer.Serialize(obj);
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
