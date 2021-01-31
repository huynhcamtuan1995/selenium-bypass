using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WindowsFormsApp
{
    public static class TestClass
    {
        public static bool MyTestClass()
        {

            //string profile = @"C:\\Users\\...";
            string url = "https://olacity.com/login";

            string chromeDriverPath = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}";
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument(profile);
            //*** have to fake user agent to avoid detect auto bot
            IWebDriver driver = new ChromeDriver(chromeDriverPath);

            driver.Navigate().GoToUrl(url);

            IWebElement ele1 = driver.FindElement(By.CssSelector("input#user_login"));
            ele1.SendKeys("mytesting");

            Thread.Sleep(2000);
            IWebElement ele2 = driver.FindElement(By.CssSelector("div.g-recaptcha iframe"));
            driver.SwitchTo().Frame(ele2);
            IWebElement ele3 = driver.FindElement(By.CssSelector("span.recaptcha-checkbox"));
            //JavascriptExecutor js = (JavascriptExecutor)driver;
            //js.executeScript("document.getElementById('//id of element').setAttribute('attr', '10')");
            //driver.execute_script("arguments[0].style.border = '1px solid red';");

            Thread.Sleep(2000);
            ele3.Click();
            //*** have to use audio challenge
            //click #recaptcha-audio-button //switch to audio
            //find element in src @".audio-source"
            //download audio src
            //upload to https://speech-to-text-demo.ng.bluemix.net/
            //get content
            //input#audio-response //send back to audio input
            //button#recaptcha-verify-button //submit form


            //recaptcha - checkbox - checked
            //driver.findElement(By.xpath("//span[@class='label']")).click();

            //    driver.switchTo().frame(
            //driver.findElements(By.tagName("iframe")).get(2));
            //    new WebDriverWait(driver, 20).until(
            //        ExpectedConditions.elementToBeClickable(By
            //            .xpath("(//span[.='Like'])[1]"))).click();

            //Thread.Sleep(1000);
            //driver.Close();

            return true;
        }
    }
}
