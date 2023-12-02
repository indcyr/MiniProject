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
    internal class SmokeHomePage
    {
        IWebDriver driver;

        public SmokeHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));

            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.Id, Using = "wzrk-cancel")]
        private IWebElement? PopUpCloseBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Fossil']")]
        private IWebElement? SelectFossil { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Gold']")]
        private IWebElement? Gold { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='3D try on']")]
        private IWebElement? ThreeDTryOn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-label='1_round']//div[@class='trendcta'][normalize-space()='Explore']")]
        private IWebElement? RoundExplore { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//img[@title='Lenskart']")]
        private IWebElement? BackToHomePage { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-label='2_cat_eye']//div[@class='trendcta'][normalize-space()='Explore']")]
        private IWebElement? CatEyeExplore { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-label='3_club_master']//div[@class='trendcta'][normalize-space()='Explore']")]
        private IWebElement? ClubMasterExplore { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-label='4_transparent']//div[@class='trendcta'][normalize-space()='Explore']")]
        private IWebElement? TransparentExplore { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='rightarrow1']")]
        private IWebElement? RightArrow { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@data-label='6_air_clip_on']//div[@class='trendcta'][normalize-space()='Explore']")]
        private IWebElement? ClipOnExplore { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/eyewear/promotion/as-seen-on-mouni-roy.html']//img")]
        private IWebElement? MouniRoyStyle { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/eyewear/collections/karan-johar-favorites.html']//img")]
        private IWebElement? KaranJoharStyle { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@data-action='MENU_EYEGLASSES']//div[@class='viewall'][normalize-space()='View All']")]
        private IWebElement? EyeGlassViewAll { get; set; }
        public void FossilGlassesSelect()
        {
            IWebElement glass = driver.FindElement(By.XPath("//a[@id='lrd1']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(glass).Build().Perform();
            Thread.Sleep(6000);

            IWebElement brand = driver.FindElement(By.XPath("//div[@class='GenderBox--16g1pp6 jVTNpb']//span[@class='GenderText--y5tvqu ePVcpP'][normalize-space()='Women']"));
            Actions action = new Actions(driver);
            action.MoveToElement(brand).Build().Perform();
            Thread.Sleep(6000);
            IWebElement premiumbrand = driver.FindElement(By.XPath("//span[normalize-space()='PREMIUM EYEGLASSES']"));
            Actions actions2 = new Actions(driver);
            action.MoveToElement(brand).Build().Perform();
            Thread.Sleep(3000);


            SelectFossil?.Click();
            Thread.Sleep(3000);
        }
        public void ClickOnGold()
        {

            PopUpCloseBtn?.Click();
            Thread.Sleep(2000);
            Gold?.Click();
        }
        public void ClickOnTryOn()
        {

            //PopUpCloseBtn?.Click();
            Thread.Sleep(3000);
            ThreeDTryOn?.Click();
        }
        
        public void ExploreTypes()
        {
            
            Thread.Sleep(3000);
            RoundExplore?.Click();
            BackToHomePage?.Click();
            Thread.Sleep(3000);
            CatEyeExplore?.Click();
            BackToHomePage?.Click();
            Thread.Sleep(3000);
            ClubMasterExplore?.Click();
            BackToHomePage?.Click();
            Thread.Sleep(3000);
            TransparentExplore?.Click();
            BackToHomePage?.Click();
            Thread.Sleep(3000);
            RightArrow?.Click();
            Thread.Sleep(3000);
            ClipOnExplore?.Click();
        }
        
        public void CelebrityStyles()
        {
            
            MouniRoyStyle?.Click();
            BackToHomePage?.Click();
            KaranJoharStyle?.Click();
            
        }
        public void MouseOverCheck()
        {
            Thread.Sleep(5000);
            IWebElement view = driver.FindElement(By.XPath("(//div[@class='dropbtn'])[1]"));
            Actions act = new Actions(driver);
            act.MoveToElement(view).Build().Perform();
            Thread.Sleep(4000);
            EyeGlassViewAll?.Click();
            Thread.Sleep(4000);
        }




    }
}

