using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManage.Selenium
{
    public class BaseTest
    {
        public ExtentReports extent = ExtentManager.getInstance();
        public static void takeScreenshot(string filename, IWebDriver driver)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\deytek\Desktop\reports\ScreenShots\" + filename + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Gif);
        }
        public static void takeScreenshotDosya(string filename, IWebDriver driver)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\deytek\Desktop\reports\ScreenShots\Dosya\" + filename + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Gif);
        }
        public static void takeScreenshotPaylasilanlar(string filename, IWebDriver driver)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\deytek\Desktop\reports\ScreenShots\Paylasilanlar\" + filename + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Gif);
        }
        public static void takeScreenshotKlasor(string filename, IWebDriver driver)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\deytek\Desktop\reports\ScreenShots\KlasorCont\" + filename + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Gif);
        }
    }
}
