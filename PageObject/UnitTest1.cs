using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObject
{

    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://old.qalight.com.ua/zapisatsya-na-kursy.html");
            driver.Manage().Window.Maximize();
            SetImplicitTimeOut(driver, 10);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Category("Smoke with PageObject")]
        [Test]
        public void SmokeWithPageObject_negavite()
        {
            //Arrange

            // Act
            OldQAlightPage oldQAlightPage = new OldQAlightPage(driver);
            var course = oldQAlightPage.course;

            SelectElement courseDropdown = new SelectElement(course);
            courseDropdown.SelectByIndex(3);

            oldQAlightPage.surnameField.SendKeys("TestSurname");
            oldQAlightPage.nameField.SendKeys("TestName");
            oldQAlightPage.MyProperty.SendKeys("0669876767");
            oldQAlightPage.submitButton.Click();

            // Assert
            Assert.True(IsElementPresent(oldQAlightPage.errorRegistrationPopoup),
                $"Element '{nameof (oldQAlightPage.errorRegistrationPopoup)}' is not present on the page.");
        }
        public bool IsElementPresent(IWebElement element)
        {
            SetImplicitTimeOut(driver, 2);
            try
            {
                var result = element.Displayed;
                SetImplicitTimeOut(driver, 10);
                return true;
            }
            catch (NoSuchElementException)
            {
                SetImplicitTimeOut(driver, 10);
                return false;
            }
            throw new Exception("Unexpected exception.");
        }

        // TODO move methode to Utils
        public void SetImplicitTimeOut(IWebDriver driver, int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        [Category("Smoke")]
        [Test]
        public void Smoke()
        {
            //Arrange

            string expectedElementLocatorFail = ".alert.alert-error";
            

            // Act
            // Fill in the form

            // select from dropdown
            IWebElement course = driver.FindElement(By.CssSelector("[name='_7c8289bf6b8e80c1749ef54ab01b92b8']"));
            SelectElement courseDropdown = new SelectElement(course);
            courseDropdown.SelectByIndex(3);


            IWebElement surnameField = driver.
                FindElement(By.XPath("//*[@id=\"z_sender0\"]"));
            surnameField.SendKeys("TestSurname");

            IWebElement nameField = driver.
                FindElement(By.XPath("//*[@id=\"z_text1\"]"));
            nameField.SendKeys("TestName");

            IWebElement phoneField = driver.
                FindElement(By.XPath("//*[@id=\"z_text0\"]"));
            phoneField.SendKeys("0669876767");

            IWebElement emailField = driver.
                FindElement(By.XPath("//*[@id=\"z_sender1\"]"));
            emailField.SendKeys("test@gmail.com");

            //IWebElement skypeField = driver.
            //  FindElement(By.XPath("//*[@id=\"z_text2\"]"));
            //skypeField.SendKeys("test_gmail");

            // select from dropdown
            IWebElement sourceInfo = driver.FindElement(By.CssSelector("[name='_e926ba2b2813f56de8fc13877057e908']"));
            SelectElement sourceInfoDropdown = new SelectElement(sourceInfo);
            sourceInfoDropdown.SelectByIndex(4);
        

            // click Submit button
            IWebElement submitButton = driver.
             FindElement(By.CssSelector("[type=submit]"));
            submitButton.Click();


             // Thread.Sleep(2000); // - заходит на стр и уходит назад

            // Assert
            Assert.True(IsElementPresent(driver, expectedElementLocatorFail),
                $"Element with locator {expectedElementLocatorFail} is not present on the page.");
        }

        public bool IsElementPresent(IWebDriver driver, string cssSelector)
        {
            var elements = driver.FindElements(By.CssSelector(cssSelector));

            if (elements.Count == 1)
            {
                return true;
            }
            else if (elements.Count == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("Unexpected Exception");
            }
        }
    }
}
