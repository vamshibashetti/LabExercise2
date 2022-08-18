using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace LabExercise
{
    [TestClass]
    public class SeleniumTest
    {
        [DataTestMethod]
        [Ignore]
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
             Thread.Sleep(3000);
            IWebElement Email= driver.FindElement(By.Id("recipient-email"));
            Email.SendKeys("vamshi@gmail.com");
            Thread.Sleep(2000);

            IWebElement Name= driver.FindElement(By.Id("recipient-name"));
            Name.SendKeys("vamshi");
            Thread.Sleep(2000);

            IWebElement Message= driver.FindElement(By.Id("message-text"));
            Message.SendKeys("done for now");
            Thread.Sleep(3000);
            driver.Quit();
            

        }  

        [DataTestMethod]
        [Ignore]
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
            
            IWebElement Close = driver.FindElement(By.XPath("//button[@onclick='send()']/preceding-sibling::button[@type='button']"));
            Close.Click();

           driver.Quit();
            

        }  

        
        [DataTestMethod]
        [DataRow("Ch","http://automationpractice.com","Customer service","ravi@gmail.com","order misplaced",@"C:\Temp\upload.txt")]
        [DataRow("FF","http://automationpractice.com","Webmaster","raju@gmail.com","order pending",@"C:\Temp\upload.txt")]
        [DataRow("Edge","http://automationpractice.com","Webmaster","rocky@gmail.com","payment",@"C:\Temp\upload.txt")]

        public void TestMethod3(string browser,string url, string subhead, string email, string orderref,string file)
        { 
          IWebDriver driver;
          SelectElement dropDown;
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
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            IWebElement Contact= driver.FindElement(By.PartialLinkText("Contact"));
            Contact.Click();
            Thread.Sleep(2000);
            IWebElement subject =driver.FindElement(By.XPath("//select[@id='id_contact']"));
             Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver) .ExecuteScript("arguments[0].scrollIntoView(true);", subject);
            dropDown = new SelectElement(subject);
            dropDown.SelectByText(subhead);
             Thread.Sleep(2000);
            IWebElement Email= driver.FindElement(By.XPath("//input[@id='email']"));
            Email.SendKeys(email);
            Thread.Sleep(2000);

           IWebElement order= driver.FindElement(By.Id("id_order"));
            order.SendKeys(orderref);
            Thread.Sleep(2000);

           IWebElement Upload= driver.FindElement(By.XPath("//span[@class='filename']"));
            Thread.Sleep(4000);
            Upload.SendKeys(file);
            Thread.Sleep(2000);
            
            /*IWebElement Close = driver.FindElement(By.XPath("//button[@onclick='send()']/preceding-sibling::button[@type='button']"));
            Close.Click();*/

           driver.Quit();
            

        }  

       
    }
}
