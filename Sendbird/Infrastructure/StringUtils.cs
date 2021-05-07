using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Sendbird.Infrastructure
{
    internal static class StringUtils
    {
        private static Regex whitespaceRegex = new Regex(@"\s", RegexOptions.CultureInvariant);

        public static string ToSnakeCase(string str)
        {
            var tmp = Regex.Replace(str, "(.)([A-Z][a-z]+)", "$1_$2");
            return Regex.Replace(tmp, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        public static bool SecureEquals(string a, string b)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            if (a.Length != b.Length)
            {
                return false;
            }

            var result = 0;

            for (var i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }

        public static bool ContainsWhitespace(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return whitespaceRegex.IsMatch(str);
        }
    }
}
