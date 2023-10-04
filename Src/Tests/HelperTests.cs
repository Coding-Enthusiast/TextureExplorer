// Texture Explorer Tests
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using TextureExplorer;

namespace Tests
{
    public class HelperTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData("  ", "")]
        [InlineData("a", "A")]
        [InlineData(" a   ", "A")]
        [InlineData(" A   ", "A")]
        [InlineData("abc", "Abc")]
        [InlineData("aBc", "Abc")]
        [InlineData("a Bb c", "A bb c")]
        public void CleanTest(string input, string expected)
        {
            string actual = input.Clean();
            Assert.Equal(expected, actual);
        }
    }
}