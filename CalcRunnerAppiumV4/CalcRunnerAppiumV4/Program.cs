using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcRunnerAppiumV4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Este projeto é muito interessante.
             Nas linhas de código a seguir, é feito uma automação da tarefa de adição de 2 + 2 
             e, em seguida, ao digitar os comandos da calculadora, a tecla = também é clicada
             automaticamente, mostrando o resultado na Calculadora do Windows.
            */
            #region Chamando a Calculadora do Windows

            WindowsDriver<WindowsElement> sessionCalculator;
            AppiumOptions appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            sessionCalculator = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                appiumOptions);

            #endregion

            // Declarando os objetos que o Appium deve clicar
            #region Variaveis que chamam os botões da Calcuradora.

            var ButtonTwo = sessionCalculator.FindElementByName("Dois");
            var ButtonMais = sessionCalculator.FindElementByName("Mais");
            var ButtonIgualA = sessionCalculator.FindElementByName("Igual a");

            #endregion

            // Declarando as operações que devem ser feitas dentro da Calculadora.
            #region Operação da Calculadora

            ButtonTwo.Click();
            ButtonMais.Click();
            ButtonTwo.Click();
            ButtonIgualA.Click();

            #endregion
        }
    }
}
