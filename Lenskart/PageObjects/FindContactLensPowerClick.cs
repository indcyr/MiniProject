using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class FindContactLensPowerClick
    {
        IWebDriver driver;
        public FindContactLensPowerClick(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//h3[normalize-space()='[+] SPH Power(CYL <0.5)']")]
        private IWebElement? ContactLensPower { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//div[@class='ImageContainer--1lleecg coaHQG'])[3]")]
        private IWebElement? SelectContactLens { get; set; }

        public SelectContactLens ContactLensSelect()
        {
            Thread.Sleep(2000);
            ContactLensPower?.Click();
            Thread.Sleep(2000);
            SelectContactLens?.Click();
            return new SelectContactLens(driver);
        }



        //public ConvertToContactLensPower ConvertToContactLensClick()
        //{
        //    ConvertToContactLens?.Click();
        //    Thread.Sleep(4000);
        //    return new ConvertToContactLensPower(driver);
        //}

    }

    
}
