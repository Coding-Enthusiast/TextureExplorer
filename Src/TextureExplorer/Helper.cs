// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Globalization;

namespace TextureExplorer
{
    public static class Helper
    {
        public static string Clean(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            ReadOnlySpan<char> temp = s.Trim().AsSpan();
            if (temp.Length == 0)
            {
                return string.Empty;
            }

            Span<char> result = new char[temp.Length];
            CultureInfo cinf = CultureInfo.CurrentCulture;
            temp.Slice(0, 1).ToUpper(result, cinf);
            temp.Slice(1).ToLower(result.Slice(1), cinf);
            return new string(result);

        }
    }
}
