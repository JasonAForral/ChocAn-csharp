using Xunit;
using System;
using ChocAn.IOAuth;

namespace ChocAn.Tests.IOAuth
{
    public class IsCurrency_Should
    {
        public readonly IOAuthentication _io;

        public IsCurrency_Should()
        {
            _io = new IOAuthentication();
        }
        [Theory]
        [InlineData(null, 6)]
        [InlineData("", 6)]
        [InlineData(" ", 6)]
        public void Should_Throw(string input, int maxLength)
        {
            Assert.Throws<ArgumentException>(() => _io.IsCurrency(input, maxLength));
        }

        [Theory]
        [InlineData("0", 6)]
        [InlineData("0.01", 6)]
        [InlineData("1", 6)]
        [InlineData("9.99", 4)]
        [InlineData("100", 6)]
        [InlineData("99.99", 5)]
        [InlineData("99", 5)]
        [InlineData("999.99", 6)]
        [InlineData("9999.99", 7)]
        [InlineData("99999.99", 8)]
        public void AcceptValues(string input, int maxLength)
        {
            Assert.True(_io.IsCurrency(input, maxLength));
        }

        [Theory]
        [InlineData("0000000", 6)]
        [InlineData("99.9999", 6)]
        [InlineData("9999.99", 6)]
        [InlineData("aaaaaaa", 6)]
        [InlineData("aaaaaaaaa", 8)]
        [InlineData("1998.1998", 8)]
        public void RejectLongInputs(string input, int maxLength)
        {
            Assert.False(_io.IsCurrency(input, maxLength));
        }

        [Theory]
        [InlineData("hat", 6)]
        [InlineData("an arm and a leg", 311)]
        [InlineData("infinity", 312)]
        [InlineData("infinity + 1", 312)]
        [InlineData("aaaaaaaaa", 9)]
        [InlineData("98.98.98", 8)]
        public void RejectNonValues(string input, int maxLength)
        {
            Assert.False(_io.IsCurrency(input, maxLength));
        }


        [Theory]
        [InlineData("10", 4)]
        [InlineData("100", 5)]
        [InlineData("1000", 6)]
        [InlineData("10000", 7)]
        [InlineData("100000", 8)]
        [InlineData("1000000", 9)]
        [InlineData("10000000", 10)]
        [InlineData("9999", 4)]
        [InlineData("99999", 5)]
        [InlineData("999999", 6)]
        [InlineData("9999999", 7)]
        [InlineData("99999999", 8)]
        [InlineData("999999999", 9)]
        [InlineData("9999999999", 10)]
        public void RejectValuesOverLimit(string input, int maxLength)
        {
            Assert.False(_io.IsCurrency(input, maxLength));
        }

        [Theory]
        [InlineData("-1", 6)]
        [InlineData("-99999", 6)]
        [InlineData("-99.99", 6)]
        public void RejectNegativeValues(string input, int maxLength)
        {
            Assert.False(_io.IsCurrency(input, maxLength));
        }
    }
}
