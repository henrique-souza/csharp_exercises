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
            //Para testar esta aplicação corretamente, você precisará:
            // 1. Ativar as Ferramentas de Desenvolvedor do Windows 10
            // 2. Baixar a versão mais recente do WinAppDriver (https://github.com/microsoft/WinAppDriver)
            // 3. Instalar o Node.Js
            // 4. Abrir o Prompt de Comando/PowerShell > executar o comando 'npm install -g appium' 
            // 5. Abrir o Visual Studio e ir no Gerenciador de Soluções
            // 6. Botão direito em Referências > Gerenciar Pacotes NuGet 
            // 7. Instalar o 'Appium.WinDriver' > Abrir o 'WinAppDriver' instalado na máquina > Compilar este código

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
