using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace MSTestOverview
{
    [TestClass]
    public class AlarmsAndClockSmokeTests
    {
        static WindowsDriver<WindowsElement> sessionAlarms;
        private static TestContext objectTestContext;

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

            objectTestContext = testContext;
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
            Assert.AreEqual("Alarmes e Relógio", sessionAlarms.Title, false,
                $"O titulo atual não condiz com o esperado: {sessionAlarms.Title}");
        }

        [TestMethod]
        public void VerifyNewClockCanBeAdded()
        {
            // dando um valor a variavel sessionAlarms
            // estes valores são justamente os botões mapeados para que o programa faça a automação
            sessionAlarms.FindElementByAccessibilityId("ClockButton").Click();

            sessionAlarms.FindElementByName("Adicionar nova cidade").Click();

            // este comando faz com que o teste seja feito com um delay de 1 segundo
            //System.Threading.Thread.Sleep(1000);

            // Este comando faz com que a automação espere até 10 segundos para que a
            // sessionAlarms esteja dentro dos objetos anteriormente apontados...
            // ele vai esperar até 10 segundos para que o programa clique em "Relógio Mundial" 
            // se caso o tempo estimado passe, o programa força a chamada da automação Appium
            WebDriverWait waitForMe = new WebDriverWait(sessionAlarms, TimeSpan.FromSeconds(10));

            // isso faz com que o programa encontre o 'radio' em que está escrito "Inserir um local"
            // dentro de alarmes e relógio
            var textLocation = sessionAlarms.FindElementByName("Inserir um local");

            waitForMe.Until(pred => textLocation.Displayed);

            //isso faz com que o programa digite as informações no 'radio' aberto anteriormente
            textLocation.SendKeys("Rio de Janeiro, Brasil");

            // isso faz com que o que foi digitado acima seja aplicado ao programa
            textLocation.SendKeys(Keys.Enter);

            var clockItems = sessionAlarms.FindElementsByClassName("ListViewItem");

            bool wasClockTileFound = false;

            WindowsElement tileFound = null;

            foreach (WindowsElement clockTile in clockItems)
            {
                if (clockTile.Text.StartsWith("Rio de Janeiro, Brasil"))
                {
                    Debug.WriteLine("Clock found.");
                    wasClockTileFound = true;
                    tileFound = clockTile;
                    break;
                }
            }
            Assert.IsTrue(wasClockTileFound, "No clock tile found.");

            
            Actions actionForRightClick = new Actions(sessionAlarms);

            // tileFound = um dos quadradinhos do Relógio, após inserir o relógio daquela região
            // isso move o mouse até o elemento descrito
            actionForRightClick.MoveToElement(tileFound);

            // faz a ação de clicar
            actionForRightClick.Click();

            // Context.Click = Automatiza o clique com Botão Direito do Mouse
            actionForRightClick.ContextClick();

            actionForRightClick.Perform();


            //No exemplo, no lugar de AppiumOptions, ele usa 'DesiredCapabilities'
            AppiumOptions capDesktop = new AppiumOptions();

            //No exemplo, no lugar de AddAdditionalCapability, ele usa 'SetCapability'
            capDesktop.AddAdditionalCapability("app", "Root");

            WindowsDriver<WindowsElement> sessionDesktop = 
                new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"), capDesktop);

            var contextItemDelete = sessionDesktop.FindElementByAccessibilityId("ContextMenuDelete");

            WebDriverWait desktopWaitForMe = new WebDriverWait(sessionDesktop, TimeSpan.FromSeconds(10));

            desktopWaitForMe.Until(pred => contextItemDelete.Displayed);

            contextItemDelete.Click();
        }
    }
}
