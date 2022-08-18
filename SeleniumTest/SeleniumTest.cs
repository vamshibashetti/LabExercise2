using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;


namespace LabExercise
{
    [TestClass]
    public class SeleniumTest
    {
        [DataTestMethod]
        [DataRow("Ch","https://www.demoblaze.com/")]

        public void TestMethod4(string browser,string url)
        { 
          IWebDriver driver;
        
          if(browser == "FF")
          {
          driver = new FirefoxDriver(@"C:\Root Folder\WebDriver");
          
          } else
          { 
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
          
          }
            driver.Navigate().GoToUrl(url);
    
            IWebElement Contact= driver.FindElement(By.LinkText("Contact"));
            Contact.Click();
             Thread.Sleep(5000);
            IWebElement Email= driver.FindElement(By.Id("recipient-email"));
            Email.SendKeys("vamshi@gmail.com");
            Thread.Sleep(2000);

            IWebElement Name= driver.FindElement(By.Id("recipient-name"));
            Name.SendKeys("vamshi");
            Thread.Sleep(2000);

            IWebElement Message= driver.FindElement(By.Id("message-text"));
            Message.SendKeys("done for now");
            Thread.Sleep(5000);
            driver.Quit();
            

        }  

        [DataTestMethod]
        [DataRow("Ch","https://www.demoblaze.com/","raju@gmail.com","raju","im tester")]
        [DataRow("FF","https://www.demoblaze.com/","kiran@gmail.com","vamshi","im automated")]
        [DataRow("Edge","https://www.demoblaze.com/","sai@gmail.com","sai","im engineer")]

        public void TestMethod2(string browser,string url,string email,string name,string msg)
        { 
          IWebDriver driver;
        
          if(browser == "FF")
          {
          driver = new FirefoxDriver(@"C:\Root Folder\WebDriver");
          
          } else if(browser == "Ch")
          { 
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
          
          } else 
          {
            driver = new EdgeDriver(@"C:\Root Folder\WebDriver");
          }
            driver.Navigate().GoToUrl(url);
    
            IWebElement Contact= driver.FindElement(By.LinkText("Contact"));
            Contact.Click();
            Thread.Sleep(5000);
            IWebElement Email= driver.FindElement(By.Id("recipient-email"));
            Email.SendKeys(email);
            Thread.Sleep(2000);

            IWebElement Name= driver.FindElement(By.Id("recipient-name"));
            Name.SendKeys(name);
            Thread.Sleep(2000);

            IWebElement Message= driver.FindElement(By.Id("message-text"));
            Message.SendKeys(msg);
            
            Thread.Sleep(5000);
            driver.Quit();
            

        }         
       
    }
}
