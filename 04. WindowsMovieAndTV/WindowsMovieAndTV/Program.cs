using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsMovieAndTV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            WindowsDriver<WindowsElement> WindowsMovieTV;
            AppiumOptions appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("app", "Microsoft.ZuneVideo_8wekyb3d8bbwe!Microsoft.ZuneVideo");

            WindowsMovieTV = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                appiumOptions);

            // Para assistir algum trailer, precisaremos do nome dos filmes listados, e um
            // prefixo '. . . .' de pontos e espaços
            WindowsMovieTV.FindElementByName("Venom: Tempo de Carnificina. . . .").Click();
        }
    }
}
