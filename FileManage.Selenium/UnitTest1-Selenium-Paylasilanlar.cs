using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileManage.Selenium
{
    [TestFixture]
    public class UnitTest1_Selenium_Paylasilanlar : BaseTest
    {
        public string connectionString = "data source=91.229.35.248;initial catalog = Filesystem_ibrahim; user id = ibrahim.yuluce; password=awq6tQN9uKUVA8VY;multipleactiveresultsets=True;application name = EntityFramework";
        [TestCase, Order(1)]
        public void Index() //Paylasilanlar/Index
        {
            var test = extent.StartTest("Index Test", "Index sayfasının kontrolü");
            test.Log(LogStatus.Info, "Index sayfasının açılış kontrolu");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                takeScreenshotPaylasilanlar("ScreenShot1", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot1.jpeg"));
                driver.Navigate().GoToUrl("localhost:51152/Paylasilanlar/Index");
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot2", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot2.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        [TestCase, Order(2)]
        public void Paylastiklarim()
        {
            var test = extent.StartTest("Paylaştıklarım Test", "Paylaştıklarım sayfasının kontrolü");
            test.Log(LogStatus.Info, "Paylaştıklarım sayfasının açılış kontrolu");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                takeScreenshotPaylasilanlar("ScreenShot3", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot3.jpeg"));
                driver.Navigate().GoToUrl("localhost:51152/Paylasilanlar/Paylastiklarim");
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot4", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot4.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        [TestCase, Order(3)]
        public void Bilgi_IdNull()
        {
            var test = extent.StartTest("Bilgi Hata Test", "Bilgi sayfasının kontrolü");
            test.Log(LogStatus.Info, "Bilgi sayfasının açılış kontrolu ve id boş durumu");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                takeScreenshotPaylasilanlar("ScreenShot5", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot5.jpeg"));
                driver.Navigate().GoToUrl("localhost:51152/Paylasilanlar/Paylastiklarim");
                Thread.Sleep(1000);
                var elementrightclick = driver.FindElement(By.XPath("//*[@id='1508']/div/span[1]"));
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                action.ContextClick(elementrightclick);
                action.Perform();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot6", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot6.jpeg"));
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html/body/ul[5]/li[3]")).Click();
                Thread.Sleep(1300);
                takeScreenshotPaylasilanlar("ScreenShot7", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot7.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        [TestCase, Order(4)]
        public void Bilgi_Ok()
        {
            var test = extent.StartTest("Bilgi Test", "Bilgi sayfasının kontrolü");
            test.Log(LogStatus.Info, "Bilgi sayfasının açılış kontrolu ve görüntülenmesi");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                takeScreenshotPaylasilanlar("ScreenShot8", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot8.jpeg"));
                driver.Navigate().GoToUrl("localhost:51152/Paylasilanlar/Paylastiklarim");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='1508']")).Click();
                var elementrightclick = driver.FindElement(By.XPath("//*[@id='1508']/div/span[1]"));
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                action.ContextClick(elementrightclick);
                action.Perform();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot9", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot9.jpeg"));
                driver.FindElement(By.XPath("/html/body/ul[5]/li[3]")).Click();
                Thread.Sleep(1300);
                takeScreenshotPaylasilanlar("ScreenShot10", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot10.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        [TestCase, Order(5)]
        public void BenimlePaylasilanlarBilgi()
        {
            var test = extent.StartTest("Benimle Paylaşılanlar Hakkında Bilgi Test", "Sayfanın açılış kontrolü");
            test.Log(LogStatus.Info, "Benimle Paylasilanlar Bilgi sayfasının  açılış kontrolu ve görüntülenmesi");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                takeScreenshotPaylasilanlar("ScreenShot11", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot11.jpeg"));
                driver.Navigate().GoToUrl("localhost:51152/Paylasilanlar/Index");
                driver.FindElement(By.XPath("//*[@id='1515']/a/h6[1]")).Click();
                Thread.Sleep(1000);
                var elementrightclick = driver.FindElement(By.XPath("//*[@id='1515']/a/h6[1]"));
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                action.ContextClick(elementrightclick);
                action.Perform();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot12", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot12.jpeg"));
                driver.FindElement(By.XPath("/html/body/ul[3]/li[3]")).Click();
                Thread.Sleep(1200);
                takeScreenshotPaylasilanlar("ScreenShot13", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot13.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        [TestCase, Order(6)]
        public void YetkiKaldirma()
        {
            var test = extent.StartTest("Yetki Kaldırma Testi", "Yetki Kaldırmanın Kontrolü");
            test.Log(LogStatus.Info, "Paylaşmış olduğumuz dosyalardan yetkinin kaldırma kontrolü");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                takeScreenshotPaylasilanlar("ScreenShot14", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot14.jpeg"));
                driver.FindElement(By.XPath("//*[@id='1519']/a/h6[1]")).Click();
                var elementrightclick = driver.FindElement(By.XPath("//*[@id='1519']/a/h6[1]"));
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                action.ContextClick(elementrightclick);
                action.Perform();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot15", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot15.jpeg"));
                driver.FindElement(By.XPath("/html/body/ul[2]/li[6]")).Click();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot16", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot16.jpeg"));
                driver.FindElement(By.XPath("//button[contains(@onclick,'1867')]")).Click();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot17", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot17.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        //BenimlePaylasilanlar --> PaylasilanlariAc
        [TestCase, Order(7)]
        public void PaylasilanlariAc()
        {
            var test = extent.StartTest("Benimle Paylaşılanlar Hakkında Bilgi Test", "Sayfanın açılış kontrolü");
            test.Log(LogStatus.Info, "Benimle Paylasilanlar Bilgi sayfasının  açılış kontrolu ve görüntülenmesi");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                takeScreenshotPaylasilanlar("ScreenShot18", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot18.jpeg"));
                driver.Navigate().GoToUrl("localhost:51152/Paylasilanlar/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='1520']")).Click();
                var elementrightclick = driver.FindElement(By.XPath("//*[@id='1520']"));
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                action.ContextClick(elementrightclick);
                action.Perform();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot19", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot19.jpeg"));
                driver.FindElement(By.XPath("/html/body/ul[6]/li[1]")).Click();
                Thread.Sleep(1000);
                takeScreenshotPaylasilanlar("ScreenShot20", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot20.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        [TestCase,Order(8)]
        //paylastiklarim sayfasına gir --> /paylasilanlar/paylastiklarim/ --> /paylasinlar/paylasilanlariac
        public void Paylastiklarimiac()
        {
            var test = extent.StartTest("/paylasilanlar/paylasilanlariac", "sayfanın açılış kontrolü");
            test.Log(LogStatus.Info, "paylasilan dosyalara ait sayfanın açılması");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotPaylasilanlar("ScreenShot21", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot21.jpeg"));
                    driver.Navigate().GoToUrl("http://localhost:51152/Paylasilanlar/Paylastiklarim");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='1508']")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1508']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    Thread.Sleep(1000);
                    takeScreenshotPaylasilanlar("ScreenShot22", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot22.jpeg"));
                    driver.FindElement(By.XPath("/html/body/ul[5]/li[1]")).Click();
                    Thread.Sleep(1000);
                    takeScreenshotPaylasilanlar("ScreenShot23", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\ScreenShot23.jpeg"));
                }
                catch(Exception e)
                {
                    test.Log(LogStatus.Info, e);
                }
            }
            else
            {
                test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
    }
}
