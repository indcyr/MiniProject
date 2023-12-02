using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class SearchContactLensPage
    {
        IWebDriver driver;
        public SearchContactLensPage(IWebDriver? driver) 
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.lenskart.com/contact-lenses/popular-searches/positive-sph-power.html']//div[@class='mainrow']")]
        private IWebElement? LensPowerOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='134538']//img[@class='ProductImage--irgn47 bQsUWK']")]
        private IWebElement?  SelectLens{ get; set; }

        
        public SelectContactLens ContactLensSelect()
        {
            LensPowerOption?.Click();
            Thread.Sleep(3000);
            SelectLens?.Click();
            Thread.Sleep(3000);
            return new SelectContactLens(driver);
        }
        
    }
}

