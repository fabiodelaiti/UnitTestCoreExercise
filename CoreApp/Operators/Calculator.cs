using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class Calculator
    {
        public IOperator OperationService { get; }
        public Calculator(IOperator operationService )
        {
            OperationService = operationService;
        }
        public int Calculate(int[] arr)
        {
           return OperationService.Execute(arr);
        }
    }
}
