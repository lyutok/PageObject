using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObject
{
    public class OldQAlightPage
    {
        public IWebDriver driver;


        public OldQAlightPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            //course = driver.FindElement(By.CssSelector("[name='_7c8289bf6b8e80c1749ef54ab01b92b8']"));
            //surnameField = driver.FindElement(By.Id("z_sender0"));

        }

        [FindsBy(How = How.CssSelector, Using = "[name=_7c8289bf6b8e80c1749ef54ab01b92b8]")]
        public IWebElement course;

        [FindsBy(How = How.Id, Using = "z_sender0")]
        public IWebElement surnameField;

        [FindsBy(How = How.Id, Using = "z_text1")]
        public IWebElement nameField;


        [FindsBy(How = How.Id, Using = "z_text0")]
        public IWebElement MyProperty {get; private set; }

        [FindsBy(How = How.CssSelector, Using = "[type=submit]")]
        public IWebElement submitButton;

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-error")]
        public IWebElement errorRegistrationPopoup;

        

    }
}
