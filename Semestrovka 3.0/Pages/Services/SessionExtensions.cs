using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Semestrovka_3._0.Pages.Services
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value) =>
            session.SetString(key, JsonSerializer.Serialize(value));

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}