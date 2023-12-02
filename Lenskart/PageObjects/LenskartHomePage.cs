using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class LenskartHomePage
    {
        IWebDriver driver;

        public LenskartHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));

            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath, Using = "//input[@class='SearchInputField--1jgnk9g ctScwW']")]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lrd5']")]
        private IWebElement? ClickSunglasses { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lrd1']")]
        private IWebElement? ClickEyeGlasses { get; set; }
        //a[@id='lrd1']

        [FindsBy(How = How.XPath, Using = "//a[@id='lrd4']")]
        private IWebElement? ClickContactLenses { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lrd9']")]
        private IWebElement? ClickStoreLocator { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[text()='1100+ Cities']")]
        private IWebElement? CityLocator { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Sign Up']")]
        private IWebElement? SignUpBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First Name*']")]
        private IWebElement? FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Last Name']")]
        private IWebElement? LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Mobile*']")]
        private IWebElement? MobileNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email*']")]
        private IWebElement? EmailId { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password*']")]
        private IWebElement? Password { get; set; }
        
        [FindsBy(How = How.Id, Using = "remove-button")]
        private IWebElement? CreateAccBtn { get; set; }
        
        [FindsBy(How = How.Id, Using = "wzrk-cancel")]
        private IWebElement? PopUpCloseBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Sign In']")]
        private IWebElement? SignInBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Mobile / Email']")]
        private IWebElement? MobileOrEmailField { get; set; }

        [FindsBy(How = How.Id, Using = "remove-button")]
        private IWebElement? SignInButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/eyeglasses/promotions/all-kids-eyeglasses.html']//img[@alt='person']")]
        private IWebElement? KidsEyeGlasses { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@class='top-level']//div[@class='widget-title'][normalize-space()='Progressive Lenses']")]
        private IWebElement? ProgressiveLens { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/progressive-lenses']//img[@class='dropTopImg']")]
        private IWebElement? ProgressiveGlassRound { get; set; }
        
        

        public SearchResultsPage TypeSearchInput(string searchtext)
        {
            if (SearchInput == null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput?.SendKeys(searchtext);
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickSearchProduct()
        {
            ClickSunglasses?.Click();
            return new SearchResultsPage(driver);
        }
        public SearchCityPage ClickOnStoreLocator()
        {
            ClickStoreLocator?.Click();
            CityLocator?.Click();
            return new SearchCityPage(driver);
        }
        public void SignUp(string fname,string lname,string phno,string emailId,string password)
        {
            Thread.Sleep(2000);
            PopUpCloseBtn?.Click();
            SignUpBtn?.Click();
            FirstName?.SendKeys(fname);
            LastName?.SendKeys(lname);
            MobileNumber?.SendKeys(phno);
            EmailId?.SendKeys(emailId);
            Password?.SendKeys(password);
            CreateAccBtn?.Click();
        }
        public void SignIn(string phno)
        {
            Thread.Sleep(2000);
            PopUpCloseBtn?.Click();
            SignInBtn?.Click();
            MobileOrEmailField?.SendKeys(phno);
            SignInButton?.Click();
            Thread.Sleep(6000);

        }
        //div[@class='ActionLinksContainer--5xj1y5 dwIEoA']//div[2]

        public FindContactLensPowerClick ClickSearchContactLenses()
        {
            ClickContactLenses?.Click();
            return new FindContactLensPowerClick(driver);
        }
        public FilteredSearchResults filterSearch()
        {
            IWebElement brand = driver.FindElement(By.XPath("//a[@id='lrd11']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(brand).Build().Perform();
            Thread.Sleep(3000);
            KidsEyeGlasses?.Click();
            return new FilteredSearchResults(driver);
        }
        
        
    }
}
