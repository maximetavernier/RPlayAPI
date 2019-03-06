using Microsoft.AspNetCore.Http;

namespace RPlay.Core.Extensions
{
    public static class HttpRequestExtension
    {
        public static string TryGetHeader(this HttpRequest request, string key, string defaultValue)
        {
            return request.Headers?.TryGetValue(key, out var header) ?? false ? header.ToString() : defaultValue;
        }
    }
}