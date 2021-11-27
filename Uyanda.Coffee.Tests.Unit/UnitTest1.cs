using System;
using Xunit;

namespace Uyanda.Coffee.Tests.Unit
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, 1 + Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
