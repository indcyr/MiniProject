using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class FilteredSearchAddToCart
    {
        IWebDriver driver;
        public FilteredSearchAddToCart(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//button[@id='btn-primary']//p[@class='PrimaryText--13w6pz3 dBOWjF']")]
        private IWebElement? SelectLenses { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='For distance or near vision (Thin, anti-glare, blue-cut options)']")]
        private IWebElement? LensType { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[@id='modal-portal']/div[@class='PackageScreenNewContainer--5hmwos iWqdap']/div[@class='SideModalWrapper--13ks23a hrPgxW']/div[@class='Content--1hzamfb jPzWXu']/div[@class='PackageStyles__PackageListWrapper-sc-1qj15q9-3 haerew']/div[@class='PackageStyles__PackagesWrapper-sc-1qj15q9-4 fnzozL']/div[2]/div[1]/div[1]")]
        private IWebElement? LensPackage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='ImageWrapper--13vge92 bCvceE']")]
        private IWebElement? ApplyCoating { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='Text--azlizv jmfRsw btnContinue']")]
        private IWebElement? ApplyCoatingBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='Text--azlizv jmfRsw btnContinue']")]
        private IWebElement? ContinueBtn { get; set; }

        public void FilteredSearchAndaddToCart()
        {
            Thread.Sleep(3000);
            SelectLenses?.Click();
            Thread.Sleep(3000);
            LensType?.Click();
            Thread.Sleep(3000);
            LensPackage?.Click();
            Thread.Sleep(3000);
            ApplyCoating?.Click();
            Thread.Sleep(3000);
            ApplyCoatingBtn?.Click();
            Thread.Sleep(3000);
            ContinueBtn?.Click();
            Thread.Sleep(3000);
        }
    }
}
