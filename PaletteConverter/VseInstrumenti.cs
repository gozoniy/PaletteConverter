using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PaletteConverter
{
    public class VseInstrumentiPaint
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Price})\n{Url}";
        }
    }
    public class VseInstrumentiSeleniumParser
    {
        public async Task<string> LoadPageSourceAsync(string url)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddArgument("--window-position=-32000,-32000"); // Прячем окно
            
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;  // Скрыть консольное окно драйвера

            using (var driver = new ChromeDriver(service,options))
            {
                driver.Navigate().GoToUrl(url);
                await Task.Delay(1500); // подождать, пока страница загрузится

                var html = driver.PageSource;

                // Сохраняем в файл
                File.WriteAllText("page.html", html);
                Console.WriteLine("Страница сохранена в page.html");

                driver.Quit();
                return html;
            }
        }
    }

}
