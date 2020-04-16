using System;

namespace CoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //var calculator = new Calculator(new SumOperator());
            //Console.WriteLine(calculator.Calculate(new[] {1,3,7 }));
            //Console.ReadLine();

            var ctr = new HomeController(new FIleSystemLogger());
            Console.WriteLine (ctr.DoAction(1, 3));
            Console.ReadLine();
        }
    }
}
