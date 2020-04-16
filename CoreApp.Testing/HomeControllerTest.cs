using System;
using Xunit;
using Moq;
namespace CoreApp.Testing
{
    public class MockLogger : ILogger
    {
        public bool ExecutedMethod = false;
        public void Log(string v)
        {
            ExecutedMethod = true;
        }
    }

    public class HomeControllerTest
    {
        [Fact]
        public void DoaCtion_Log_AtLeastOnce()
        {
            // costruisco il controller 
            var logger = new MockLogger();
            var controller = new HomeController(logger);
            Console.WriteLine("constructor called");
            // invoco il metodo
            controller.DoAction(1, 2);
            //Verifico che scriva "Start DoaCtion"
            Assert.True(logger.ExecutedMethod);

        }


        /// <summary>
        /// Il metodo logga il nome del metodo stesso preceduto da Start
        /// </summary>
        [Fact]
        public void DoAction_Logs_MethodWithStartPrefix()
        {
            var moqLogger = new Mock<ILogger>();
            var controller = new HomeController(moqLogger.Object);
            controller.DoAction(1, 2);
            moqLogger.Verify(m => m.Log("Start DoAction"), Times.Once);
        }

        [Fact]
        public void DoAction_Logs_MethodWithEndPrefix()
        {
            var moqLogger = new Mock<ILogger>();
            var controller = new HomeController(moqLogger.Object);
            controller.DoAction(1, 2);
            moqLogger.Verify(m => m.Log("End DoAction"), Times.Once);
        }

        [Fact]
        public void DoaCtion_Logs_Twice()
        {
            var moqLogger = new Mock<ILogger>();
            var homeController = new HomeController(moqLogger.Object);
            homeController.DoAction(1, 2);
            moqLogger.Verify(m => m.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [Fact]
        public void DoaCtion_Logs_Start()
        {
            var moqLogger = new Mock<ILogger>();
            var homeController = new HomeController(moqLogger.Object);
            homeController.DoAction(1, 2);
            moqLogger.Verify(m => m.Log(It.Is<string>(s => s.Contains("Start"))), Times.Exactly(1));
        }

    }
}
