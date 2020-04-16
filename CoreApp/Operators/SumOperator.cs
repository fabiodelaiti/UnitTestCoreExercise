using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreApp
{
    public class SumOperator : IOperator
    {
        private readonly int _number1;
        private readonly int _number2;
        public SumOperator(int number1, int number2)
        {
            _number1 = number1;
            _number2 = number2;
        }
        public SumOperator()
        {
        }
        public int Calculate() 
        {
            if (_number1 < 0)
                throw new ArgumentException($"{_number1}: valore non valido");
            return _number1 + _number2;
        }

        public int Execute(int[] numbers)
        {
            return numbers.Sum();
        }

    }
}
