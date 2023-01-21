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
    public class SongParser
    {
        public static List<Song> Parser(string url)
        {
            WebDriver driver = new ChromeDriver(@"C:/chromedriver_win32/");
            driver.Navigate().GoToUrl(url);
            IJavaScriptExecutor js = driver;
            List<Song> Songs = new List<Song>();
            Task.Delay(2000).Wait();
            try
            {   
                for (int i = 0; i < 5; i++)
                {
                    Task.Delay(300).Wait();
                    if (!string.IsNullOrEmpty(url))
                    {

                        List<IWebElement> tables = driver.FindElements(By.XPath("/html/body/div/music-app/div[3]/div/div/div/music-container/music-container/div/div[2]/div//div//music-image-row")).ToList();
                        string? name = null;
                        string? singer = null;
                        string? album = null;
                        string? duration = null;
                        if (tables != null && tables.Count > 0)
                        {
                            foreach (var table in tables)
                            {
                                var html = table.GetAttribute("innerHTML");
                                name = table.FindElement(By.XPath(".//div[1]/music-link")).GetAttribute("title");
                                singer = table.FindElement(By.XPath(".//div[2]/div/music-link[1]/a")).Text;
                                album = table.FindElement(By.XPath(".//div[2]/div/music-link[2]/a")).Text;
                                duration = table.FindElement(By.XPath(".//div[3]/music-link/span")).Text;
                                Song song = new Song(name, album, duration, singer);
                                if(!Songs.Contains(song))
                                    Songs.Add(song);
                            }
                        }
                        else
                        {
                            tables = driver.FindElements(By.XPath("/html/body/div/music-app/div[3]/div/div/div/music-container/music-container/div/div[2]/div//div//music-text-row")).ToList();
                            foreach (var table in tables)
                            {
                                name = table.FindElement(By.CssSelector(".col1>music-link")).GetAttribute("title");
                                album = "";
                                singer = "";
                                duration = table.FindElement(By.CssSelector(".col4>music-link")).GetAttribute("title");
                                Song song = new Song(name, album, duration, singer);
                                if (!Songs.Contains(song))
                                    Songs.Add(song);
                            }
                        }
                    }
                    js.ExecuteScript("window.scrollBy(0,1000)");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Dispose();
            }
            return Songs;
        }
    }
}
