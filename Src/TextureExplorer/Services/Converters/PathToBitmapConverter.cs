// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System;
using System.Globalization;
using System.IO;

namespace TextureExplorer.Services.Converters
{
    internal class PathToBitmapConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            if (value is string dir && targetType.IsAssignableFrom(typeof(Bitmap)))
            {
                if (Directory.Exists(dir))
                {
                    foreach (var item in Directory.EnumerateFiles(dir))
                    {
                        if (item.Contains("preview", StringComparison.OrdinalIgnoreCase))
                        {
                            return new Bitmap(item);
                        }
                    }
                }

                return null;
            }

            throw new NotSupportedException();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
