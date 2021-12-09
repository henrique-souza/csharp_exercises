using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace MSTestOverview
{
    [TestClass]
    public class AlarmsAndClockSmokeTests
    {

        [TestMethod]
        public void TestAlarmsAndClockIsLaunchingSuccessfully()
        {
            WindowsDriver<WindowsElement> sessionAlarms;
            //No exemplo, no lugar de AppiumOptions, ele usa 'DesiredCapabilities'
            AppiumOptions capCalc = new AppiumOptions();

            //No exemplo, no lugar de AddAdditionalCapability, ele usa 'SetCapability'
            capCalc.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");

            sessionAlarms = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"), capCalc);

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
