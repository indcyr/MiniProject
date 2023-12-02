using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class SearchCityPage
    {
        IWebDriver driver;
        public SearchCityPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.ClassName, Using = "pac-target-input")]
        private IWebElement? CitySearchInput { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='index_subcontainer__vOgEh']//div[1]//div[1]//div[3]//div[4]//a[1]//button[1]")]
        private IWebElement? StoreDetails { get; set; }
        public void StoreSearch(string city)
        {
            CitySearchInput?.SendKeys(city);
            Thread.Sleep(3000);
            CitySearchInput?.SendKeys(Keys.ArrowDown);
            Thread.Sleep(3000);
            CitySearchInput?.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            StoreDetails?.Click();
        }
    }
}
