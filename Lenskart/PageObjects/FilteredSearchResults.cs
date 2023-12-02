using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class FilteredSearchResults
    {
        IWebDriver driver;
        public FilteredSearchResults(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[@id='suited_for_id']//div[3]//label[1]//div[1]")]
        private IWebElement? AgeGrpFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='https://static.lenskart.com/images/cust_mailer/Eyeglass/Square.png']")]
        private IWebElement? FrameShapeFilter { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='FRAME COLOR']")]
        private IWebElement? FrameColorFilterDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[2]/main[1]/div[2]/div[1]/div[2]/aside[1]/div[4]/div[2]/div[1]/div[2]/label[1]/div[1]")]
        private IWebElement? FrameColorFilter { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id='200339']//img[@class='ProductImage--irgn47 bQsUWK']")]
        private IWebElement? SelectFrame { get; set; }


        public FilteredSearchAddToCart FilterGlasses()
        {
            AgeGrpFilter?.Click();
            FrameShapeFilter?.Click();
            Thread.Sleep(3000);
            FrameColorFilterDropdown.Click();
            Thread.Sleep(3000);
            FrameColorFilter?.Click();
            Thread.Sleep(3000);
            SelectFrame?.Click();
            Thread.Sleep(3000);
            return new FilteredSearchAddToCart(driver);
        }
    }
}
