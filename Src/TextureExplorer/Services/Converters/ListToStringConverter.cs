// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TextureExplorer.Services.Converters
{
    public class ListToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is IEnumerable<string> lst && targetType.IsAssignableFrom(typeof(string)))
            {
                if (!lst.Any())
                {
                    return string.Empty;
                }

                // Tags are 5 chars on average, 3-6 tags is 15-30 char total. Default capacity of SB is 16 (too low).
                StringBuilder sb = new(32);
                foreach (var item in lst)
                {
                    sb.AppendLine(item);
                }
                sb.Length -= Environment.NewLine.Length;
                return sb.ToString();
            }

            throw new NotImplementedException();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
