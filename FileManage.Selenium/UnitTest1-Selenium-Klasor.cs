using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.SqlClient;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Net.Mail;
using System.Net;

namespace FileManage.Selenium
{
    [TestFixture]
    public class UnitTest1_Selenium_Klasor : BaseTest
    {
        public static void Uyu()
        {
            Thread.Sleep(1000);
        }
        public string connectionString = "data source=91.229.35.248;initial catalog = Filesystem_ibrahim; user id = ibrahim.yuluce; password=awq6tQN9uKUVA8VY;multipleactiveresultsets=True;application name = EntityFramework";
        int a = 0;
        //Klasor Silinecek
        [TestCase, Order(1)]
        public void Edits()
        {
            var test = extent.StartTest("Klasor Isminin Değiştirilmesi");
            test.Log(LogStatus.Info, "Klasor isimlerinin değişiminin kontrolü");
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
                    takeScreenshotKlasor("ScreenShot1", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot1.jpeg"));
                    driver.FindElement(By.XPath("//*[@id='1522']")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1522']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[2]")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.ClassName("yeniden-adlandir")).SendKeys("yeni dosya");
                    takeScreenshotKlasor("ScreenShot2", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot2.jpeg"));
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='isimDegistirModal']/div/div/div[3]/button[2]")).Click();
                    Thread.Sleep(1200);
                    takeScreenshotKlasor("ScreenShot3", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot3.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase,Order(2)]
        public void Sil()
        {
            var test = extent.StartTest("Klasor silme işleminin kontrolü", "Sil Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Klasorun silinip silinmediğinin kontrolü");
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
                    takeScreenshotKlasor("ScreenShot4", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot4.jpeg"));
                    driver.FindElement(By.XPath("//*[@id='1522']")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1522']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[3]")).Click();
                    Thread.Sleep(1200);
                    takeScreenshotKlasor("ScreenShot5", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot5.jpeg"));
                    driver.FindElement(By.XPath("//*[@id='myModal']/div/div/div[3]/button[2]"));
                    Thread.Sleep(1000);
                    takeScreenshotKlasor("ScreenShot6", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot6.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(15)]
        public void KlasorYarat()
        {
            var test = extent.StartTest("Klasor yaratılma işleminin kontrolü", "Creates Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Klasorun başarılı bir şekilde yaratılması beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot7", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot7.jpeg"));
                    Uyu();Uyu();
                    driver.FindElement(By.ClassName("yeni-klasor-yarat")).Click();
                    Uyu();
                    driver.FindElement(By.ClassName("add-folder-name")).SendKeys("BySelenium");
                    Uyu();
                    takeScreenshotKlasor("ScreenShot8", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot8.jpeg"));
                    driver.FindElement(By.ClassName("add-folder-name-button")).Click();
                    Uyu(); Uyu();
                    takeScreenshotKlasor("ScreenShot9", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot9.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase,Order(4)]
        public void KlasorAc()
        {
            var test = extent.StartTest("Yaratılan klasorlerin içeriklerinin görme işlemi");
            test.Log(LogStatus.Info, "Yaratılmış klasorun içindeki dosya ve klasorlerin başarılı bir şekilde görüntülenme işlemi");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot10", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot10.jpeg"));
                    Uyu(); Uyu();
                    driver.FindElement(By.XPath("//*[@id='1522']")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1522']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[1]")).Click();
                    Uyu();
                    takeScreenshotKlasor("ScreenShot11", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot11.jpeg"));
                }
                catch (Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase,Order(5)]
        public void CreateINFolder()
        {
            var test = extent.StartTest("Klasor içinde klasor yaratma testi", "CreateInFolde Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Klasorun başarılı bir şekilde yaratılması beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot10", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot10.jpeg"));
                    Uyu(); Uyu();
                    driver.FindElement(By.ClassName("yeni-klasor-yarat")).Click();
                    Uyu();
                    driver.FindElement(By.ClassName("add-folder-name")).SendKeys("Klasor-1");
                    Uyu();
                    takeScreenshotKlasor("ScreenShot11", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot11.jpeg"));
                    driver.FindElement(By.ClassName("add-folder-name-button")).Click();
                    Uyu(); Uyu();
                    takeScreenshotKlasor("ScreenShot12", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot12.jpeg"));
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='1527']")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1527']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[1]")).Click();
                    Uyu();
                    takeScreenshotKlasor("ScreenShot13", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot13.jpeg"));
                    Uyu();
                    driver.FindElement(By.ClassName("yeni-klasor-yarat")).Click();
                    Uyu();
                    driver.FindElement(By.ClassName("add-folder-name")).SendKeys("Klasor-2");
                    Uyu();
                    takeScreenshotKlasor("ScreenShot14", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot14.jpeg"));
                    driver.FindElement(By.ClassName("add-folder-name-button")).Click();
                    Uyu(); Uyu();
                    takeScreenshotKlasor("ScreenShot15", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot15.jpeg"));
                }
                catch (Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(6)]
        public void RenameINFolder()
        {
            var test = extent.StartTest("Klasor icindeki klasorun isminin degisitirilme testi", "RenameINFolder Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Klasor isminin başarılı bir şekilde değişmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot16", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot16.jpeg"));
                    Uyu(); Uyu();
                    driver.FindElement(By.ClassName("yeni-klasor-yarat")).Click();
                    Uyu();
                    driver.FindElement(By.ClassName("add-folder-name")).SendKeys("Klasor-1");
                    Uyu();
                    takeScreenshotKlasor("ScreenShot17", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot17.jpeg"));
                    driver.FindElement(By.ClassName("add-folder-name-button")).Click();
                    Uyu(); Uyu();
                    takeScreenshotKlasor("ScreenShot18", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot18.jpeg"));
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='1540']")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1540']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[1]")).Click();
                    Uyu();
                    takeScreenshotKlasor("ScreenShot19", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot19.jpeg"));
                    Uyu();
                    driver.FindElement(By.ClassName("yeni-klasor-yarat")).Click();
                    Uyu();
                    driver.FindElement(By.ClassName("add-folder-name")).SendKeys("Klasor-2");
                    Uyu();
                    takeScreenshotKlasor("ScreenShot20", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot20.jpeg"));
                    driver.FindElement(By.ClassName("add-folder-name-button")).Click();
                    Uyu(); Uyu();
                    takeScreenshotKlasor("ScreenShot21", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot21.jpeg"));
                    driver.FindElement(By.XPath("//*[@id='1541']")).Click();
                    var elementrightclick1 = driver.FindElement(By.XPath("//*[@id='1541']"));
                    var action1 = new OpenQA.Selenium.Interactions.Actions(driver);
                    action1.ContextClick(elementrightclick1);
                    action1.Perform();
                    Uyu();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[2]")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.ClassName("yeniden-adlandir")).SendKeys("yeni isim");
                    takeScreenshotKlasor("ScreenShot22", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot22.jpeg"));
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='isimDegistirModal']/div/div/div[3]/button[2]")).Click();
                    Thread.Sleep(1200);
                    takeScreenshotKlasor("ScreenShot23", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot23.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(7)]
        public void DeleteINFolder()
        {
            var test = extent.StartTest("Klasor içinde klasorun silme testi", "DeleteINFolder Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Klasorun başarılı bir şekilde silinmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot24", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot24.jpeg"));
                    Uyu(); Uyu();
                    driver.FindElement(By.XPath("//*[@id='1540']")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1540']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[1]")).Click();
                    Uyu();
                    takeScreenshotKlasor("ScreenShot27", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot27.jpeg"));
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='1541']")).Click();
                    var elementrightclick1 = driver.FindElement(By.XPath("//*[@id='1541']"));
                    var action1 = new OpenQA.Selenium.Interactions.Actions(driver);
                    action1.ContextClick(elementrightclick1);
                    action1.Perform();
                    Thread.Sleep(1200);
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[3]")).Click();
                    Thread.Sleep(2000);
                    takeScreenshotKlasor("ScreenShot28", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot28.jpeg"));
                    driver.FindElement(By.XPath("//button[contains(@onclick,'Sil')]")).Click();
                    Thread.Sleep(1000);
                    takeScreenshotKlasor("ScreenShot29", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot29.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(8)]
        public void DosyaInDelete()
        {
            var test = extent.StartTest("Klasor içindeki dosyanın silinme testi", "DosyaInDelete Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Dosyanın başarılı bir şekilde silinmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot30", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot30.jpeg"));
                    Uyu(); Uyu();
                    driver.FindElement(By.XPath("//*[@id='1522']/div/span[1]")).Click();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1522']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    Uyu();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[1]")).Click();
                    Uyu();
                    var elementrightclick1 = driver.FindElement(By.XPath("//*[@id='1523']"));
                    var action1 = new OpenQA.Selenium.Interactions.Actions(driver);
                    action1.ContextClick(elementrightclick1);
                    action1.Perform();
                    Uyu();
                    driver.FindElement(By.XPath("/html/body/ul[2]/li[4]")).Click();
                    takeScreenshotKlasor("ScreenShot31", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot31.jpeg"));
                    Uyu();
                    driver.FindElement(By.XPath("//button[contains(@onclick,'dosyaSil')]")).Click();
                    Thread.Sleep(1000);
                    takeScreenshotKlasor("ScreenShot32", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot32.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(9)]
        public void TekliDosyaDownload()
        {
            var test = extent.StartTest("Tek bir dosyanın indirilme işlemi", "TekliDosyaDownload metodunun çalıştırılması");
            test.Log(LogStatus.Info, "Dosyanın başarılı olarak indirilmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot33", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot33.jpeg"));
                    Uyu(); Uyu();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1514']/a/h6[1]"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/ul[2]/li[1]")).Click();
                    Thread.Sleep(1000);
                    takeScreenshotKlasor("ScreenShot34", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot34.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(10)]
        public void TekliKlasorDownload()
        {
            var test = extent.StartTest("Tek bir klasorun indirilme testi", "TekliKlasorDownload Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Klasorun indirilme işlemi başarıyla gerçekleşmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot35", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot35.jpeg"));
                    Uyu(); Uyu();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1508']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    takeScreenshotKlasor("ScreenShot36", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot36.jpeg"));
                    Uyu();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[4]")).Click();
                    Thread.Sleep(3000);
                    takeScreenshotKlasor("ScreenShot37", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot37.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(11)]
        public void CokluDosyaDownload()
        {
            var test = extent.StartTest("Çoklu Dosya Indirme Testi", "CokluDosyaDownload metodunun çalıştırılması.");
            test.Log(LogStatus.Info, "Dosyaların başarılya indirilmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot38", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot38.jpeg"));
                    Uyu(); Uyu();
                    var first_element = driver.FindElement(By.XPath("//*[@id='1514']/a/h6[1]"));
                    var second_element = driver.FindElement(By.XPath("//*[@id='1516']/a/h6[1]"));
                    Actions actions = new Actions(driver);
                    actions.KeyDown(Keys.LeftControl)
                        .Click(first_element)
                        .Click(second_element)
                        .KeyUp(Keys.LeftControl)
                        .Build().Perform();
                    Thread.Sleep(1200);
                    driver.FindElement(By.XPath("//button[contains(@onclick,'klasordosyaindir')]")).Click();
                    Thread.Sleep(2700);
                    takeScreenshotKlasor("ScreenShot39", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot39.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(12)]
        public void KlasorDosyaDownload()
        {
            var test = extent.StartTest("Klasor Dosya Birlikte Indirme", "KlasorDosyaDownload metodunun çalıştırılması");
            test.Log(LogStatus.Info, "Klasor ve Dosyaların başarıyla indirilmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot40", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot40.jpeg"));
                    Uyu(); Uyu();
                    var first_element = driver.FindElement(By.XPath("//*[@id='1508']"));
                    var second_element = driver.FindElement(By.XPath("//*[@id='1514']/a/h6[1]"));
                    Actions actions = new Actions(driver);
                    actions.KeyDown(Keys.LeftControl)
                        .Click(first_element)
                        .Click(second_element)
                        .KeyUp(Keys.LeftControl)
                        .Build().Perform();
                    Thread.Sleep(1200);
                    driver.FindElement(By.XPath("//button[contains(@onclick,'klasordosyaindir')]")).Click();
                    Thread.Sleep(2700);
                    takeScreenshotKlasor("ScreenShot41", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot41.jpeg"));
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(13)]
        public void KlasorIciDosyaDownload()
        {
            var test = extent.StartTest("Klasor Ici Dosya İndirme", "KlasorIciDosyaDownload metodunun çalıştırılması");
            test.Log(LogStatus.Info, "Klasor icinde dosya indirme işlemi");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot42", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot42.jpeg"));
                    Uyu(); Uyu();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1508']"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    driver.FindElement(By.XPath("/html/body/ul[1]/li[1]")).Click();
                    Thread.Sleep(1000);
                    var elementrightclick1 = driver.FindElement(By.XPath("//*[@id='1511']/span/h6[1]"));
                    var action1 = new OpenQA.Selenium.Interactions.Actions(driver);
                    action1.ContextClick(elementrightclick1);
                    action1.Perform();
                    takeScreenshotKlasor("ScreenShot43", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot43.jpeg"));
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/ul[2]/li[1]")).Click();
                    Thread.Sleep(2200);
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase, Order(14)]
        public void VideoPlayerAnaSayfa()
        {
            var test = extent.StartTest("AnaSayfadaki text dosyasının açılması", "VideoPlayer metodnun çalıştırılması");
            test.Log(LogStatus.Info, "Düzgün bir şekilde görütülenmesi beklenmektedir.");
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
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
                    Uyu();
                    driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                    takeScreenshotKlasor("ScreenShot44", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot44.jpeg"));
                    Uyu(); Uyu();
                    var elementrightclick = driver.FindElement(By.XPath("//*[@id='1514']/a/h6[1]"));
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(elementrightclick);
                    action.Perform();
                    takeScreenshotKlasor("ScreenShot45", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot45.jpeg"));
                    Thread.Sleep(1200);
                    driver.FindElement(By.XPath("/html/body/ul[2]/li[2]")).Click();
                    Uyu();
                    takeScreenshotKlasor("ScreenShot46", driver);
                    test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\ScreenShot46.jpeg"));
                    Uyu();
                    driver.FindElement(By.ClassName("text-kapat")).Click();
                }
                catch(Exception e)
                {
                    a = a + 1;
                    test.Log(LogStatus.Warning, e);
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
        [TestCase,Order(16)]
        public void SendEmail()
        {
            if(a != 0)
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mailMessage = new MailMessage();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("coffeedeneme123@gmail.com", "1234Asdf");
                smtp.EnableSsl = true;
                var subject = "Test Sırasında bir hata bulundu";
                var body = "Test aşamasında gerçekleşen hatayı ekte inceleyebilirsiniz.";
                var gonderilecekmail = "ibrahimyuluce@hotmail.com";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@"C:\Users\deytek\Desktop\reports\report.html");
                mailMessage.Attachments.Add(attachment);
                mailMessage.From = new MailAddress("coffeedeneme123@gmail.com");
                mailMessage.Body = body;
                mailMessage.Subject = subject;
                mailMessage.To.Add(gonderilecekmail);
                smtp.Send(mailMessage);
            }
        }
    }
}
