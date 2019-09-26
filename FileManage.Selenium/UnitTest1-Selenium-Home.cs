using System;
using System.Data;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using RelevantCodes.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Data.SqlClient;

namespace FileManage.Selenium
{
    [TestFixture]
    public class UnitTest1 : BaseTest
    {
        public string connectionString = "data source=91.229.35.248;initial catalog = Filesystem_ibrahim; user id = ibrahim.yuluce; password=awq6tQN9uKUVA8VY;multipleactiveresultsets=True;application name = EntityFramework";
        [TestCase,Order(1)]
        public void Index()
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
                driver.Url = "localhost:51152/Home/Index";
                Thread.Sleep(1000);
                takeScreenshot("ScreenShot", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot.jpeg"));
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
        public void GirisYap()
        {
            var test = extent.StartTest("Giriş Yap Test", "Sisteme Giriş Yap Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Giriş sayfasının açılış kontrolu");
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
                takeScreenshot("ScreenShot1", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot1.jpeg"));
            }
            else
            {
                test.Log(LogStatus.Warning,"Database bağlantısı sağlanamadı");
            }
            extent.EndTest(test);
            extent.Flush();
            connection.Close();
            driver.Quit();
        }
        [TestCase,Order(3)]
        public void Logout()
        {
            var test = extent.StartTest("Logout Testi", "Sistemden çıkış yapmanın kontrolü");
            test.Log(LogStatus.Info, "Çıkış yapmanın kontrolu");
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
                takeScreenshot("ScreenShot2", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot2.jpeg"));
                driver.FindElement(By.XPath("//*[@id='userbox']")).Click();
                Thread.Sleep(2000);
                takeScreenshot("ScreenShot3", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot3.jpeg"));
                driver.FindElement(By.XPath("//*[@id='userbox']/div/ul/li[4]")).Click();
                Thread.Sleep(1000);
                takeScreenshot("Screenshot4", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Screenshot4.jpeg"));
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
        public void ParolamıUnuttum()
        {
            var test = extent.StartTest("Parolamı Unuttum Testi", "Parolamı Unuttum Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "parolamı unuttum sayfasının açılış kontrolu ve işlemler");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("localhost:51152/Home/Index");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html/body/section/div/form/div/div[2]/div[2]/div[1]/a")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/form/section/div/div/div[2]/div[2]/div/input")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(1000);
                takeScreenshot("ScreenShot5", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot5.jpeg"));
                driver.FindElement(By.XPath("/html/body/section/div/form/section/div/div/div[2]/div[2]/div/span/button")).Click();
                Thread.Sleep(1200);
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
        public void ResetPassword()
        {
            var test = extent.StartTest("Parola Sıfırlama Testi", "ResetPassword Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Parola sıfırlma işleminin çalışmasının kontrolü");
            IWebDriver driver = new ChromeDriver();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                test.Log(LogStatus.Info, "Database Bağlantı başarılı");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:51152/Home/ResetPassword?code=f4dd36ca-c1b6-45ea-8492-328d6c046955");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@name='sifre1']")).SendKeys("1234");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@name='sifre2']")).SendKeys("1234");
                Thread.Sleep(1000);
                takeScreenshot("ScreenShot6", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot6.jpeg"));
                driver.FindElement(By.XPath("/html/body/section/div/form/section/div/div/div[2]/span/button")).Click();
                Thread.Sleep(1000);
                takeScreenshot("ScreenShot7", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot7.jpeg"));
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
        public void UyeKaydet_TcHata()
        {
            var test = extent.StartTest("Kullanıcı Ekle Fail Test", "Sisteme Kullanıcı Ekleme Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Hatalı Kullanıcı ekleme kontrol testi");
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
                takeScreenshot("ScreenShot8", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot8.jpeg"));
                driver.FindElement(By.XPath("//*[@id='menu']/ul/li[2]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[1]/input")).SendKeys("16259411741");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[2]/input")).SendKeys("ibrahim");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[3]/input")).SendKeys("yülüce");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//*[@id='datetimepicker1']/input")).SendKeys("13/02/1996");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//*[@id='mail-adres']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[6]/div/div[1]/input")).SendKeys("1234");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[6]/div/div[2]/input")).SendKeys("1234");
                Thread.Sleep(500);
                takeScreenshot("ScreenShot9", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot9.jpeg"));
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                var tchata = driver.FindElement(By.Id("tc-uyusmadi"));
                if (tchata != null)
                {
                    string hatamesaji = tchata.Text;
                    takeScreenshot("ScreenShot10", driver);
                    test.Log(LogStatus.Info, hatamesaji + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot10.jpeg"));
                }
                Thread.Sleep(1000);
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
        public void UyeKaydet_Basarili()
        {
            var test = extent.StartTest("Kullanıcı Ekle Başarılı Test", "Sisteme Kullanıcı Ekleme Metodunun Çalıştırılması");
            test.Log(LogStatus.Info, "Doğru Kullanıcı bilgileriyle ekleme kontrolü");
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
                takeScreenshot("ScreenShot11", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot11.jpeg"));
                driver.FindElement(By.XPath("//*[@id='menu']/ul/li[2]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[1]/input")).SendKeys("16259411740");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[2]/input")).SendKeys("ibrahim");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[3]/input")).SendKeys("yülüce");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//*[@id='datetimepicker1']/input")).SendKeys("13/02/1996");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//*[@id='mail-adres']")).SendKeys("ibrahimyuluce@hotmail.com");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[6]/div/div[1]/input")).SendKeys("1234");
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/section/div/section/form/section/div[2]/div/div[6]/div/div[2]/input")).SendKeys("1234");
                Thread.Sleep(500);
                takeScreenshot("ScreenShot12", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot12.jpeg"));
                driver.FindElement(By.XPath("//*[@id='submit']")).Click();
                Thread.Sleep(1000);
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
        //[TestCase,Order(5)]
        //public void KlasorDownload()
        //{
        //    var test = extent.StartTest("Tekli Klasor Indirme Testi", "Sistemden klasordownload metodunun çalıştırılması ");
        //    test.Log(LogStatus.Info, "Klasorun inme kontrol testi");
        //    IWebDriver driver = new ChromeDriver();
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    if (connection.State == ConnectionState.Open)
        //    {
        //        test.Log(LogStatus.Info, "Database Bağlantı başarılı");
        //        driver.Manage().Window.Maximize();
        //        driver.Navigate().GoToUrl("localhost:51152/Home/Index");
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("//*[@id='submit']")).Click();
        //        takeScreenshot("ScreenShot1", driver);
        //        test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot1.jpeg"));
        //        var elementrightclick = driver.FindElement(By.XPath("//*[@id='1508']/div/div[1]"));
        //        var action = new OpenQA.Selenium.Interactions.Actions(driver);
        //        action.ContextClick(elementrightclick);
        //        action.Perform();
        //        Thread.Sleep(1000);
        //        takeScreenshot("ScreenShot5", driver);
        //        test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot5.jpeg"));
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("/html/body/ul[1]/li[4]")).Click();
        //        Thread.Sleep(1700);
        //    }
        //    else
        //    {
        //        test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
        //    }
        //    extent.EndTest(test);
        //    extent.Flush();
        //    connection.Close();
        //    driver.Quit();
        //}
        //[TestCase, Order(6)]
        //public void DosyaDownload()
        //{
        //    var test = extent.StartTest("Tekli Dosya Download Test", "Sistemden tekli dosya indirme metodu");
        //    test.Log(LogStatus.Info, "Tekli Dosya Indirme");
        //    IWebDriver driver = new ChromeDriver();
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    if (connection.State == ConnectionState.Open)
        //    {
        //        test.Log(LogStatus.Info, "Database Bağlantı başarılı");
        //        driver.Manage().Window.Maximize();
        //        driver.Navigate().GoToUrl("localhost:51152/Home/Index");
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("//*[@id='KullaniciMaili']")).SendKeys("ibrahimyuluce@hotmail.com");
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("//*[@id='KullaniciSifresi']")).SendKeys("1234");
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("//*[@id='submit']")).Click();
        //        takeScreenshot("ScreenShot1", driver);
        //        test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot1.jpeg"));
        //        var elementrightclick = driver.FindElement(By.XPath("//*[@id='1513']/a/span"));
        //        var action = new OpenQA.Selenium.Interactions.Actions(driver);
        //        action.ContextClick(elementrightclick);
        //        action.Perform();
        //        takeScreenshot("ScreenShot6", driver);
        //        test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\ScreenShot6.jpeg"));
        //        Thread.Sleep(1000);
        //        driver.FindElement(By.XPath("/html/body/ul[2]/li[1]")).Click();
        //        Thread.Sleep(1700);
        //    }
        //    else
        //    {
        //        test.Log(LogStatus.Warning, "Database bağlantısı sağlanamadı");
        //    }
        //    extent.EndTest(test);
        //    extent.Flush();
        //    connection.Close();
        //    driver.Quit();
        //}
    }
}
