using System;
using Xunit;

namespace CoreApp.Tests
{
    public class SumServiceTest
    {
        [Fact]
        public void NoAddends()
        {
            var service = new SumService();
            Assert.Equal(0, service.Calculate());
        }

        [Fact]
        public void FirstAddend_1()
        {
            var service = new SumService {Number1 =1 };
            Assert.Equal(1, service.Calculate());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void FirstAddend(int val)
        {
            var service = new SumService { Number1 = val};
            Assert.Equal(val, service.Calculate());
        }

    }
}
