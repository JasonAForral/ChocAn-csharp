
using System;
using Xunit;
using ChocAn.DataClasses;

namespace ChocAn.Tests.DataClasses
{
    public class Member_Should
    {
        private readonly Member _member;
        private readonly string[] testArray;
        public Member_Should()
        {
            testArray = new string[] { "Joe Mama", "123456789", "123 N Witch Way", "Paris", "TX", "75460", "Valid"};

            _member = new Member(testArray);
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
            Assert.IsAssignableFrom<User>(_member);
        }

        [Fact]
        public void Display()
        {
            _member.Display();
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
            _member[i] = testArray[i];
            Assert.Equal(testArray[i], _member[i]);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(7)]
        public void ThrowOutOfRangeException(int i)
        {
            _ = Assert.Throws<IndexOutOfRangeException>(() => _member[i] = "TEST");
            _ = Assert.Throws<IndexOutOfRangeException>(() => _ = _member[i]);
        }
    }
}
