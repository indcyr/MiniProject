using Lenskart.PageObjects;
using Lenskart.TestScripts;
using MiniProj.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class SearchResultsPage
    {
        IWebDriver driver;
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[@class='ProductContainer--1h5el3b bIsubZ'][1]")]
        private IWebElement? SelectProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='ProductContainer--1h5el3b bIsubZ'])[position()=2]")]
        private IWebElement? SelectSunglass { get; set; }

        public SelectLensAndAddToCart ClickProduct()
        {

            SelectProduct?.Click();
            return new SelectLensAndAddToCart(driver);
        }
        public SelectLensAndAddToCart SelectEyewear()
        {
            SelectSunglass?.Click();
            return new SelectLensAndAddToCart(driver);
        }
    }
}
