using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

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

            sessionCalculator.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            #endregion

            // Declarando os objetos que o Appium deve clicar
            #region Variaveis que chamam os botões da Calcuradora.

            var buttonTwo = sessionCalculator.FindElementByName("Dois");
            var buttonMais = sessionCalculator.FindElementByName("Mais");
            var buttonIgualA = sessionCalculator.FindElementByName("Igual a");
            var calculatorResults = sessionCalculator.FindElementByAccessibilityId("CalculatorResults");

            #endregion

            // Declarando as operações que devem ser feitas dentro da Calculadora.
            #region Operação da Calculadora

            buttonTwo.Click();
            buttonMais.Click();
            buttonTwo.Click();
            buttonIgualA.Click();

            #endregion

            #region Outra forma de declarar as Variáveis e realizar as operações da Calculadora

            // Outra forma de realizar a operação acima
            // Com menos linhas de código

            /*
            var ButtonTwo = sessionCalculator.FindElementByName("Dois");
            ButtonTwo.Click();
            sessionCalculator.FindElementByName("Mais").Click();
            ButtonTwo.Click();
            sessionCalculator.FindElementByName("Igual a").Click();
            */

            #endregion

            #region Mostrando o resultado e testando condições

            Console.WriteLine($"Valor mostrado pela Calculadora: {calculatorResults.Text}");

            if (calculatorResults.Text.EndsWith("4"))
            {
                Console.WriteLine("O resultado está correto.");
            }
            else
            {
                Console.WriteLine("O resultado está incorreto.");
            }

            #endregion

            //Nesta linha, a calculadora apaga o resultado da operação acima
            calculatorResults.SendKeys(Keys.Escape);

            #region Fazendo a mesma operação que acima, mas sem puxar o clique do Mouse

            calculatorResults.SendKeys("2");
            calculatorResults.SendKeys("+");
            calculatorResults.SendKeys("2");
            calculatorResults.SendKeys("=");

            Console.WriteLine($"Valor mostrado pela Calculadora: {calculatorResults.Text}");

            if (calculatorResults.Text.EndsWith("4"))
            {
                Console.WriteLine("O resultado está correto.");
            }
            else
            {
                Console.WriteLine("O resultado está incorreto.");
            }

            #endregion
        }
    }
}
