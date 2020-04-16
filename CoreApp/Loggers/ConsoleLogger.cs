using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string v)
        {
            Console.WriteLine(v);
        }
    }
}
