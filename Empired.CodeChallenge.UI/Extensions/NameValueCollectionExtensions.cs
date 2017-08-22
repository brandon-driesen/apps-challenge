using System.Collections.Generic;
using System.Collections.Specialized;

namespace Empired.CodeChallenge.UI
{
   
    public static class NameValueCollectionExtensions
    {
        public static string GetValueOrDefault(this NameValueCollection collection, KeyValuePair<string, string> setting)
        {
            var value = collection[setting.Key];
            if (string.IsNullOrWhiteSpace(value))
            {
                return setting.Value;
            }
            return value;
        }
    }
}
