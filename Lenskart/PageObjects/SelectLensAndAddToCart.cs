using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProj.PageObjects
{
    internal class SelectLensAndAddToCart
    {
        IWebDriver driver;
        public SelectLensAndAddToCart(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        ////div[contains(@class,'AddToCartButtonWrapper')]//child::button//child::p[text()='SELECT LENSES']
        [FindsBy(How = How.XPath, Using = "//button[@id='btn-primary']")]
        private IWebElement? SelectLensBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='zero_power']")]
        private IWebElement? SelectLensType { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='BLU Thin ZP']")]

        private IWebElement? SelectLensPackage { get; set; }

        [FindsBy(How = How.ClassName, Using = "wishlist-icon")]
        private IWebElement? WishListBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='CartStyles__ButtonContent-sc-14bvp3n-7 dcNbQW']")]
        private IWebElement? CheckOutBtn { get; set; }
        public void SelectLensButtonClick()
        {
            Thread.Sleep(3000);
            SelectLensBtn?.Click();
        }

        public void LensTypeSelection()
        {

            Thread.Sleep(3000);
            SelectLensType?.Click();
        }
        public void AddToCart()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => SelectLensPackage.Displayed);
            SelectLensPackage?.Click();
            Thread.Sleep(3000);
            CheckOutBtn?.Click();
            Thread.Sleep(3000);
        }
        public void AddToWishList()
        {
            WishListBtn?.Click();
            Thread.Sleep(3000);
        }
       



    }
}
