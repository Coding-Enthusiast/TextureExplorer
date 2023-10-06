// Texture Explorer Tests
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using TextureExplorer.Services.Converters;

namespace Tests.Converters
{
    public class ListToStringConverterTests
    {
        public static IEnumerable<object[]> GetCovertCases()
        {
            yield return new object[] { Array.Empty<string>(), string.Empty };
            yield return new object[] { new string[] { "foo" }, "foo" };
            yield return new object[] { new string[] { "foo", "bar" }, $"foo{Environment.NewLine}bar" };
            yield return new object[] { new string[] { "foo", "bar", "baz" }, $"foo{Environment.NewLine}bar{Environment.NewLine}baz" };
        }
        [Theory]
        [MemberData(nameof(GetCovertCases))]
        public void ConvertTest(IEnumerable<string> input, string expected)
        {
            ListToStringConverter conv = new();
            object? actual = conv.Convert(input, typeof(string), null, null);
            Assert.Equal(expected, actual);
        }
    }
}
