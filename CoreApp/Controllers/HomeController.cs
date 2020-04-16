using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class HomeController
    {
        private readonly ILogger logger;

        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }
       
        public string DoAction(int par1, int par2 )
        {
            try
            {
                logger.Log("Start DoAction");
                return $"{par1} {par1}";
            }
            finally
            {
                logger.Log("End DoAction");
            }
        }
    }
}
