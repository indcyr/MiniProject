using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.PageObjects
{
    internal class ConvertToContactLensPower
    {
        IWebDriver driver;
        public ConvertToContactLensPower(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/form[1]/div[3]/ul[2]/li[2]/select[1]")]
        private IWebElement? RightSphDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='sphr']/option[text()='1.00']")]
        private IWebElement? RightSphPower { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='cylr']")]
        private IWebElement? RightCylDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='cylr']/option[@value='-3.50']")]
        private IWebElement? RightCylPower { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='axisr']")]
        private IWebElement? RightEyeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='axisr']/option[@value='165']")]
        private IWebElement? RightEyeAxis { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='sphl']")]
        private IWebElement? LeftSphDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='sphl']/option[@value='0.50']")]
        private IWebElement? LeftSphPower { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='cyll']/option[@value='-3.00']")]
        private IWebElement? LeftCylPower { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='axisl']/option[@value='180']")]
        private IWebElement? LeftEyeAxis { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='submit']")]
        private IWebElement? SubmitBtn { get; set; }

        public void GetContactLensPower()
        {
            Thread.Sleep(3000);
            RightSphDropdown?.Click();
            Thread.Sleep(3000);
            RightSphPower?.Click();
            Thread.Sleep(3000);
            RightCylPower?.Click();
            RightEyeAxis?.Click();
            Thread.Sleep(2000);
            LeftSphPower?.Click();
            LeftCylPower?.Click();
            LeftEyeAxis?.Click();
            Thread.Sleep(2000);
            SubmitBtn?.Click();
            Thread.Sleep(4000);
        }
    }
}

