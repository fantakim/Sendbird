using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Infrastructure
{
    internal static class FormEncoder
    {
        public static HttpContent CreateHttpContent(BaseOptions options)
        {
            if (options == null)
            {
                return new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
            }

            return new FormUrlEncodedContent(options);
        }

        public static string CreateQueryString(BaseOptions options)
        {
            var flatParams = FlattenParamsValue(options, null)
                .Where(kvp => kvp.Value is string)
                .Select(kvp => new KeyValuePair<string, string>(
                    kvp.Key,
                    kvp.Value as string));
            return CreateQueryString(flatParams);
        }

        public static string CreateQueryString(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            return string.Join(
                "&",
                nameValueCollection.Select(kvp => $"{UrlEncode(kvp.Key)}={UrlEncode(kvp.Value)}"));
        }

        private static string UrlEncode(string value)
        {
            return WebUtility.UrlEncode(value)
                .Replace("%5B", "[")
                .Replace("%5D", "]")
                .Replace("%2C", ",");
        }

        private static List<KeyValuePair<string, object>> FlattenParamsValue(object value, string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = null;

            switch (value)
            {
                case null:
                    flatParams = SingleParam(keyPrefix, string.Empty);
                    break;

                case INestedOptions options:
                    flatParams = FlattenParamsOptions(options, keyPrefix);
                    break;

                case IDictionary dictionary:
                    flatParams = FlattenParamsDictionary(dictionary, keyPrefix);
                    break;

                case string s:
                    flatParams = SingleParam(keyPrefix, s);
                    break;

                case Stream s:
                    flatParams = SingleParam(keyPrefix, s);
                    break;

                case IEnumerable enumerable:
                    flatParams = FlattenParamsList(enumerable, keyPrefix);
                    break;

                case DateTime dateTime:
                    flatParams = SingleParam(
                        keyPrefix,
                        dateTime.ToEpoch().ToString(CultureInfo.InvariantCulture));
                    break;

                case Enum e:
                    flatParams = SingleParam(keyPrefix, JsonUtils.SerializeObject(e).Trim('"'));
                    break;

                default:
                    flatParams = SingleParam(
                        keyPrefix,
                        string.Format(CultureInfo.InvariantCulture, "{0}", value));
                    break;
            }

            return flatParams;
        }

        private static List<KeyValuePair<string, object>> FlattenParamsOptions(
            INestedOptions options,
            string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();
            if (options == null)
            {
                return flatParams;
            }

            foreach (var property in options.GetType().GetRuntimeProperties())
            {
                var extensionAttribute = property.GetCustomAttribute<JsonExtensionDataAttribute>();
                if (extensionAttribute != null)
                {
                    var extensionValue = property.GetValue(options, null) as IDictionary;

                    flatParams.AddRange(FlattenParamsDictionary(extensionValue, keyPrefix));
                    continue;
                }

                var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                if (attribute == null)
                {
                    continue;
                }

                var value = property.GetValue(options, null);

                if (value == null)
                {
                    continue;
                }

                string key = attribute.PropertyName;
                string newPrefix = NewPrefix(key, keyPrefix);

                flatParams.AddRange(FlattenParamsValue(value, newPrefix));
            }

            return flatParams;
        }

        private static List<KeyValuePair<string, object>> FlattenParamsDictionary(
            IDictionary dictionary,
            string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();
            if (dictionary == null)
            {
                return flatParams;
            }

            foreach (DictionaryEntry entry in dictionary)
            {
                string key = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
                object value = entry.Value;

                string newPrefix = NewPrefix(key, keyPrefix);

                flatParams.AddRange(FlattenParamsValue(value, newPrefix));
            }

            return flatParams;
        }

        private static List<KeyValuePair<string, object>> FlattenParamsList(
            IEnumerable list,
            string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();
            if (list == null)
            {
                return flatParams;
            }

            int index = 0;
            foreach (object value in list)
            {
                string newPrefix = $"{keyPrefix}[{index}]";
                flatParams.AddRange(FlattenParamsValue(value, newPrefix));
                index += 1;
            }

            if (!flatParams.Any())
            {
                flatParams.Add(new KeyValuePair<string, object>(keyPrefix, string.Empty));
            }

            return flatParams;
        }

        private static List<KeyValuePair<string, object>> SingleParam(string key, object value)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();
            flatParams.Add(new KeyValuePair<string, object>(key, value));
            return flatParams;
        }

        private static string NewPrefix(string key, string keyPrefix)
        {
            if (string.IsNullOrEmpty(keyPrefix))
            {
                return key;
            }

            int i = key.IndexOf("[", StringComparison.Ordinal);
            if (i == -1)
            {
                return $"{keyPrefix}[{key}]";
            }
            else
            {
                return $"{keyPrefix}[{key.Substring(0, i)}]{key.Substring(i)}";
            }
        }
    }
}
