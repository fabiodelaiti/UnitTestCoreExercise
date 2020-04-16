using System;
using Xunit;

namespace CoreApp.Testing
{
    public class SumOperatorTest
    {
       
        [Fact]
        public void Calculate_FirstAddendum_1()
        {
            var service = new SumOperator (1,0);
            var result = service.Calculate();
            Assert.Equal(1, result);
        }

        [Fact]
        public void Calculate_FirstAddendum_1_SecondAddendum_1()
        {
            var service = new SumOperator(  1, 1 );
            var result = service.Calculate();
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculate_FirstAddendum_LessThan0()
        {
            var service = new SumOperator(-1, 1);
            var ex =  Assert.Throws<ArgumentException>(() => service.Calculate());
            Assert.Contains("non valido", ex.Message);
        }

        [Theory]
        [InlineData(3,1)]
        [InlineData(5,1)]
        public void Calculate(int firstAddendum, int secondAddendum)
        {
            var service = new SumOperator(firstAddendum, secondAddendum);
            var result = service.Calculate();
            Assert.Equal(firstAddendum + secondAddendum, result);
        }

        [Fact]
        public void Execute_AllGreaterThaThan0()
        {
            var service = new SumOperator();
            var addends = new[] { 1, 2, 3 };
            var result = service.Execute(addends);
            Assert.Equal(6, result);
        }
    }
}
