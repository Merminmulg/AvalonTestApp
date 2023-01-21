using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AvalonTestApp.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace AvalonTestApp.DataSetter
{
    public class AlbumTitleParser
    {
        public static AlbumTitle Parser(string url)
        {
            WebDriver driver = new ChromeDriver(@"C:/chromedriver_win32/");
            driver.Navigate().GoToUrl(url);
            AlbumTitle albumTitle = new AlbumTitle("Error", "Error", "Error");
            Task.Delay(2000).Wait();
            try
            {
                IWebElement table = driver.FindElement(By.XPath("/html/body/div/music-app/div[3]/div/div/div/music-detail-header"));
                var shadowRoot = table.GetShadowRoot();
                IWebElement shadowContent = shadowRoot.FindElement(By.CssSelector(".container"));
                var html = shadowContent.GetAttribute("innerHTML");
                var imageUrl = shadowContent.FindElement(By.CssSelector("music-image")).GetAttribute("src");
                string title = shadowContent.FindElement(By.CssSelector("h1")).Text;
                string discription = shadowContent.FindElement(By.CssSelector("header>div>p>music-link")).Text;
                albumTitle = new AlbumTitle(title, discription, imageUrl);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Dispose();
            }
            return albumTitle;
        }
    }
}
