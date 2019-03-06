using System.Collections.Generic;

namespace RPlay.Core.Extensions
{
    public static class StringExtension
    {
        public static string ReplaceAll(this string input, List<string> oldValues, string newValue)
        {
            var result = input;
            oldValues.ForEach((old) => { result = result.Replace(old, newValue); });
            return result;
        }
    }
}