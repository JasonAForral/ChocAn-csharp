
using System;
using Xunit;
using ChocAn.DataClasses;

namespace ChocAn.Tests.DataClasses
{
    public class Provider_Should
    {
        private readonly Provider _provider;
        private readonly string[] testArray;
        public Provider_Should()
        {
            testArray = new string[] { "Joe Mama", "123456789", "123 N Witch Way", "Paris", "TX", "75460", "123456"};

            _provider = new Provider(testArray);
        }

        [Fact]
        public void RejectNull()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new Member(null));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1", "2")]
        [InlineData("1", "2", "3")]
        [InlineData("1", "2", "3", "4")]
        [InlineData("1", "2", "3", "4", "5")]
        public void RejectIncompleteMemberData(params string [] args)
        {
            Assert.Throws<ArgumentException>(() => new Member(args));
        }

        [Fact]
        public void BeAUser()
        {
            Assert.IsAssignableFrom<User>(_provider);
        }

        [Fact]
        public void Display()
        {
            _provider.Display();
            Assert.True(true);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void BeIndexed(int i)
        {
            _provider[i] = testArray[i];
            Assert.Equal(testArray[i], _provider[i]);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(7)]
        public void ThrowOutOfRangeException(int i)
        {
            _ = Assert.Throws<IndexOutOfRangeException>(() => _provider[i] = "TEST");
            _ = Assert.Throws<IndexOutOfRangeException>(() => _ = _provider[i]);
        }
    }
}
