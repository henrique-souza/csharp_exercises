using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;

namespace AcessarNavegador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            // tô dando uma de doido e me auto-sugeri um exercício antes da seção 6
            // do curso de Automação com C#. Simbora.

            /*
             * Eu imaginei que o objetivo deste código possa ser abrir o navegador, digitar o link
             * de algum site e clicar em alguma coisa deste site... Sei lá, Youtube. Clicar em alguma
             * coisa dentro do Youtube, que seja acessível tanto pra mim quanto pra quem for testar
             * isso algum dia. É nós.
            */
            #region Abrindo o Microsoft Edge
            WindowsDriver<WindowsElement> edgeSession;

            AppiumOptions desiredCapabilities = new AppiumOptions();

            desiredCapabilities.AddAdditionalCapability("app", @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");

            edgeSession = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723/"), desiredCapabilities);
            #endregion

            #region Encontrando a barra de pesquisa, digitando e acessando Youtube
            var digitandoURL = edgeSession.FindElementByName("Barra de pesquisa e endereços");

            WebDriverWait waitForMe = new WebDriverWait(edgeSession, TimeSpan.FromSeconds(10));

            waitForMe.Until(pred => digitandoURL.Displayed);

            digitandoURL.SendKeys("youtube.com");

            digitandoURL.SendKeys(Keys.Enter);
            #endregion

            /*
             * Oi, Henrique do Futuro. 
             * Você parou na Seção 6 da Udemy neste momento, e não conseguiu automatizar uma pesquisa
             * no Youtube. Volte quando tiver essa capacidade.
             * É nós.
             */
        }
    }
}
