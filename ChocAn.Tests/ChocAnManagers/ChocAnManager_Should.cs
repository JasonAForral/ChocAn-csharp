using Xunit;
using ChocAn.Manager;

namespace ChocAn.Tests.Manager
{
    public class ChocAnManager_Should
    {
        readonly ChocAnManager manager;

        public ChocAnManager_Should()
        {
            manager = new ChocAnManager();
        }

        [Fact]
        public void Test1()
        {
            _ = manager;
            Assert.True(true);
        }
    }
}
