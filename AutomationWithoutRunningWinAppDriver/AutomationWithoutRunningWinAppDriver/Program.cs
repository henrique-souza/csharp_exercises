using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWithoutRunningWinAppDriver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\hss_h\
            var appiumLocalService = new AppiumServiceBuilder().UsingPort(4723).
                WithLogFile(new FileInfo(@"C:\Users\hs.santos\Documents\Logs\TestLog.txt")).Build();

            appiumLocalService.Start();

            AppiumOptions appiumOption = new AppiumOptions();

            appiumOption.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            // O underline abaixo '_' subistitui o comando 'WindowsDriver<WindowsElement> session ='
            // porque o objeto 'session' não estava sendo chamado. A IDE chamou de 'cálculo de valores redundantes',
            // foi uma atribuição desnecessária no código.
            // Então o underline é como se fosse um simbolo de descarte especiais.
            // Pode ser seguido por um inteiro, por exemplo '_1', '_2', etc.

            WindowsDriver<WindowsElement> session = new WindowsDriver<WindowsElement>(appiumLocalService, appiumOption);

            // a partir desta linha, foi solicitado a chamada do objeto 'session'
            // então irei reescrever a linha acima
            
            session.Quit();
        }
    }
}
