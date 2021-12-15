using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AcessarNavegador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tô dando uma de doido e me auto-sugeri um exercício antes da seção 6
            // do curso de Automação com C#. Simbora.

            /*
             * Eu imaginei que o objetivo deste código possa ser abrir o navegador, digitar o link
             * de algum site e clicar em alguma coisa deste site... Sei lá, Youtube. Clicar em alguma
             * coisa dentro do Youtube, que seja acessível tanto pra mim quanto pra quem for testar
             * isso algum dia. É nós.
            */
            WindowsDriver<WindowsElement> edgeSession;

            AppiumOptions desiredCapabilities = new AppiumOptions();

            desiredCapabilities.AddAdditionalCapability("app", @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");

            edgeSession = new WindowsDriver<WindowsElement>(
                new Uri ("http://127.0.0.1:4723/"), desiredCapabilities);
        }
    }
}
