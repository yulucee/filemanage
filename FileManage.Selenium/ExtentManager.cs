using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using RelevantCodes.ExtentReports;

namespace FileManage.Selenium
{
    public class ExtentManager
    {
        private static ExtentReports extent; 
        public static ExtentReports getInstance()
        {
            if(extent == null)
            {
                extent = new ExtentReports(@"C:\Users\deytek\desktop\reports\report.html");
            }
            return extent;
        }
    }
}
