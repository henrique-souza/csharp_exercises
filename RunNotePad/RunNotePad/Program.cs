using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunNotePad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Para testar esta aplicação corretamente, você precisará atirar as Ferramentas de Desenvolvedor do
            //Windows 10 > Baixar a versão mais recente do WinAppDriver (https://github.com/microsoft/WinAppDriver) >
            // > Ir no Gerenciador de Soluções > Botão direito em Referências > Gerenciar Pacotes NuGet >
            // > Instalar o 'Appium.WinDriver' > Abrir o WinAppDriver instalado na máquina > Compilar este código

            WindowsDriver<WindowsElement> notePadSession;
            AppiumOptions desiredCapabilities = new AppiumOptions();

            desiredCapabilities
                .AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");

            notePadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"),
                desiredCapabilities);

            if (notePadSession == null)
            {
                Console.WriteLine("Aplicação não foi aberta");
                return;
            }

            Console.WriteLine($"Título da Aplicação: {notePadSession.Title}");

            notePadSession.Manage().Window.Maximize();

            var screenShot = notePadSession.GetScreenshot();

            screenShot.SaveAsFile($".\\Screenshot{DateTime.Now.ToString("ddMMyyyyhhmmss")}.png",
                OpenQA.Selenium.ScreenshotImageFormat.Png);

            //notePadSession.Close();

            notePadSession.Quit();
        }
    }
}
