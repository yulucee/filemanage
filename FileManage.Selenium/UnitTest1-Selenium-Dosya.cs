using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileManage.Selenium
{
    [TestFixture]
    public class UnitTest1_Selenium_Dosya : BaseTest
    {
        public string connectionString = "data source=91.229.35.248;initial catalog = Filesystem_ibrahim; user id = ibrahim.yuluce; password=awq6tQN9uKUVA8VY;multipleactiveresultsets=True;application name = EntityFramework";
        [TestCase, Order(1)]
        public void Edits()
        {
            var test = extent.StartTest("Dosya İsim Değiştirme Test", "Dosyanın isminin değiştirilmesi");
            test.Log(LogStatus.Info, "isim değişirme işleminin çalışmasının kontrolü");
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
                takeScreenshotDosya("ScreenShot", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot.jpeg"));
                var elementrightclick = driver.FindElement(By.XPath("//*[@id='1518']"));
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                action.ContextClick(elementrightclick);
                action.Perform();
                Thread.Sleep(1000);
                takeScreenshotDosya("ScreenShot2", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot2.jpeg"));
                driver.FindElement(By.XPath("/html/body/ul[2]/li[3]")).Click();
                Thread.Sleep(1200);
                driver.FindElement(By.XPath("//*[@id='DosyaId']")).SendKeys("newfile");
                takeScreenshotDosya("ScreenShot3", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot3.jpeg"));
                Thread.Sleep(1200);
                driver.FindElement(By.XPath("//*[@id='dosyaIsimDegistirModal']/div/div/div[3]/button[2]")).Click();
                Thread.Sleep(1000);
                takeScreenshotDosya("ScreenShot5", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot5.jpeg"));
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
        public void DosyaSil()
        {
            var test = extent.StartTest("Dosya Silme Test", "Dosyanın silinme işlemi");
            test.Log(LogStatus.Info, "sil metodunun kontrolü");
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
                takeScreenshotDosya("ScreenShot6", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot6.jpeg"));
                var elementrightclick = driver.FindElement(By.XPath("//*[@id='1518']/a/span"));
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                action.ContextClick(elementrightclick);
                action.Perform();
                Thread.Sleep(1000);
                takeScreenshotDosya("ScreenShot7", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot7.jpeg"));
                driver.FindElement(By.XPath("/html/body/ul[2]/li[4]")).Click();
                Thread.Sleep(1000);
                takeScreenshotDosya("ScreenShot8", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot8.jpeg"));
                driver.FindElement(By.XPath("//*[@id='myDosyaModal']/div/div/div[3]/button[2]")).Click();
                Thread.Sleep(1200);
                takeScreenshotDosya("ScreenShot9", driver);
                test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot9.jpeg"));
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
        //[TestCase, Order(3)]
        //public void DosyaYukle()
        //{
        //    var test = extent.StartTest("Dosya İsim Değiştirme Test", "Dosyanın isminin değiştirilmesi");
        //    test.Log(LogStatus.Info, "isim değişirme işleminin çalışmasının kontrolü");
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
        //        takeScreenshotDosya("ScreenShot10", driver);
        //        test.Log(LogStatus.Info, "Screenshot" + test.AddScreenCapture(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\ScreenShot10.jpeg"));
        //        Thread.Sleep(2000);
        //    }
        //    extent.EndTest(test);
        //    extent.Flush();
        //    connection.Close();
        //}

    }
}
//IWebElement droparea = driver.FindElement(By.XPath("//*[@id='desktop']"));
//DropFile(droparea, @"C:\Users\deytek\Desktop\Newfolder\config.txt");
//const string JS_DROP_FILE = "for(var b=arguments[0],k=arguments[1],l=arguments[2],c=b.ownerDocument,m=0;;){var e=b.getBoundingClientRect(),g=e.left+(k||e.width/2),h=e.top+(l||e.height/2),f=c.elementFromPoint(g,h);if(f&&b.contains(f))break;if(1<++m)throw b=Error('Element not interractable'),b.code=15,b;b.scrollIntoView({behavior:'instant',block:'center',inline:'center'})}var a=c.createElement('INPUT');a.setAttribute('type','file');a.setAttribute('style','position:fixed;z-index:2147483647;left:0;top:0;');a.onchange=function(){var b={effectAllowed:'all',dropEffect:'none',types:['Files'],files:this.files,setData:function(){},getData:function(){},clearData:function(){},setDragImage:function(){}};window.DataTransferItemList&&(b.items=Object.setPrototypeOf([Object.setPrototypeOf({kind:'file',type:this.files[0].type,file:this.files[0],getAsFile:function(){return this.file},getAsString:function(b){var a=new FileReader;a.onload=function(a){b(a.target.result)};a.readAsText(this.file)}},DataTransferItem.prototype)],DataTransferItemList.prototype));Object.setPrototypeOf(b,DataTransfer.prototype);['dragenter','dragover','drop'].forEach(function(a){var d=c.createEvent('DragEvent');d.initMouseEvent(a,!0,!0,c.defaultView,0,0,0,g,h,!1,!1,!1,!1,0,null);Object.setPrototypeOf(d,null);d.dataTransfer=b;Object.setPrototypeOf(d,DragEvent.prototype);f.dispatchEvent(d)});a.parentElement.removeChild(a)};c.documentElement.appendChild(a);a.getBoundingClientRect();return a;";
//static void DropFile(IWebElement target, string filePath, double offsetX = 0, double offsetY = 0)
//{
//    if (!File.Exists(filePath))
//        throw new FileNotFoundException(filePath);

//    IWebDriver driver = ((RemoteWebElement)target).WrappedDriver;
//    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

//    IWebElement input = (IWebElement)jse.ExecuteScript(JS_DROP_FILE, target, offsetX, offsetY);
//    input.SendKeys(filePath);
//}