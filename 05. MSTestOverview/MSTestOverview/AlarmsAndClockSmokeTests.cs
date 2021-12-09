using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace MSTestOverview
{
    [TestClass]
    public class AlarmsAndClockSmokeTests
    {
        static WindowsDriver<WindowsElement> sessionAlarms;


        [ClassInitialize]
        public static void PrepareForTestingAlarms(TestContext testContext)
        {
            Debug.WriteLine("Hello ClassInitialize");

            //No exemplo, no lugar de AppiumOptions, ele usa 'DesiredCapabilities'
            AppiumOptions capCalc = new AppiumOptions();

            //No exemplo, no lugar de AddAdditionalCapability, ele usa 'SetCapability'
            capCalc.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");

            sessionAlarms = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"), capCalc);
        }

        [ClassCleanup]

        public static void CleanupAfterAllAlarmsTests()
        {
            Debug.WriteLine("Hello ClassCleanup");

            if (sessionAlarms != null)
            {
                sessionAlarms.Quit();
            }
        }

        [TestInitialize]

        public void BeforeATest()
        {
            Debug.WriteLine("Before a test, calling TestInitialize");
        }

        [TestCleanup]

        public void AfterATest()
        {
            Debug.WriteLine("After a test, calling TestCleanup");
        }

        [TestMethod]

        public void JustAnotherTest()
        {
            Debug.WriteLine("Hello, another test.");
        }

        [TestMethod]
        public void TestAlarmsAndClockIsLaunchingSuccessfully()
        {
            // Testando se o título é igual ao digitado ou não
            // caso não seja, imprime na mensagem de falha do Teste o que está escrito
            // a partir de $ e o título Real.
            // Se colocarmos "Alarmes e RelógioS" de propósito, o programa irá rodar, mas o teste
            // irá falhar.
            Assert.AreEqual("Alarmes e RelógioS", sessionAlarms.Title, false,
                $"O titulo atual não condiz com o esperado: {sessionAlarms.Title}");
        }
    }
}
