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
            WindowsDriver<WindowsElement> sessionCalculator;
            AppiumOptions appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            sessionCalculator = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                appiumOptions);

            sessionCalculator.FindElementByName("");
        }
    }
}
