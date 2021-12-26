using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace WindowsMovieAndTV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            WindowsDriver<WindowsElement> windowsMovieTV;
            AppiumOptions appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("app", "Microsoft.ZuneVideo_8wekyb3d8bbwe!Microsoft.ZuneVideo");

            windowsMovieTV = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                appiumOptions);

            // Para assistir algum trailer, precisaremos do nome dos filmes listados, e um
            // prefixo '. . . .' de pontos e espaços
            windowsMovieTV.FindElementByName("Venom: Tempo de Carnificina. . . .").Click();
        }
    }
}
