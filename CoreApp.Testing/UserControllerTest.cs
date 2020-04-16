using System;
using Xunit;
using Moq;
namespace CoreApp.Testing
{
    public class UserControllerTest
    {
        /// <summary>
        /// Insert Invoca Repository.Add con il parametro username
        /// </summary>
        [Fact]
        public void Insert_UserName_Fabio_Persists_Fabio() 
        {
            var moqLogger = new Mock<ILogger>();
            var moqRepo = new Mock<IRepository>();
            var controller = new UserController(moqLogger.Object, moqRepo.Object);
            controller.Insert("Fabio");
            moqRepo.Verify(m => m.AddUser("Fabio"), Times.Once());


        }


        [Fact]
        public void Insert_Logs_Twice()
        {
            var moqLogger = new Mock<ILogger>();
            var moqRepo = new Mock<IRepository>();
            var homeController = new UserController(moqLogger.Object, moqRepo.Object);
            homeController.Insert("Fabio");
            moqLogger.Verify(m=> m.Log(It.IsAny<string>()),Times.Exactly(2));
        }

        [Fact]
        public void Insert_Logs_Exception_IfRepositoryFails()
        {
            var moqLogger = new Mock<ILogger>();
            var moqRepo = new Mock<IRepository>();
            moqRepo.Setup(r => r.AddUser(It.IsAny<string>())).Throws(new Exception());

            var homeController = new UserController(moqLogger.Object, moqRepo.Object);
            try
            {
                homeController.Insert("Fabio");
            }
            catch
            {
            }
            moqLogger.Verify(m => m.Log(It.Is<string>(s=>s.Contains("failed") && s.Contains("Fabio"))), Times.Once());
        }


    }
}
