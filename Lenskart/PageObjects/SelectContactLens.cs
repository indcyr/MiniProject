using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class SelectContactLens
    {
        IWebDriver driver;
        public SelectContactLens(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[5]//select[1]/option[@value='2']")]
        private IWebElement? LeftLensBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='pdp-cl-info-section-118539']//div//div[6]//select[1]/option[@value='3']")]
        private IWebElement? RightLensBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[8]//select[1]/option[@value='-3.00']")]
        private IWebElement? LeftEyePower { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[9]//select[1]/option[@value='-2.75']")]
        private IWebElement? RightEyePower { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='btn-primary-cl']")]
        private IWebElement? BuyNowBtn { get; set; }

        public void ContactLensAddToCart()
        {
            LeftLensBoxes?.Click();
            Thread.Sleep(3000);
            RightLensBoxes?.Click();
            Thread.Sleep(6000);
            LeftEyePower?.Click();
            Thread.Sleep(6000);
            RightEyePower?.Click();
            Thread.Sleep(3000);
            BuyNowBtn?.Click();
            Thread.Sleep(3000);
        }
    }
}
