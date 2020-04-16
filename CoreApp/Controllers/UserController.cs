using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class UserController
    {

        private readonly ILogger logger;
        private readonly IRepository repo;

        public UserController(ILogger logger, IRepository repo)
        {
            this.logger = logger;
            this.repo = repo;
        }
        public int Insert(string userName)
        {
            try
            {
                logger.Log("Start Insert");
                return repo.AddUser(userName);
            }
            catch (Exception ex)
            {
                logger.Log($"Insert User {userName} failed");
                return -1; 
            }
            finally
            {
                logger.Log("End Insert");
            }
                           
        }
    }
}
