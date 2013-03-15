﻿using System;
using Framework.UserActions;
using OpenQA.Selenium;

namespace Framework.Helpers
{
    public class HomePageHelper : DependentActions
    {
        private readonly ApplicationManager _manager;

        public HomePageHelper()
        {
            _manager = new ApplicationManager();
        }
        public void CloseWelcomePopup()
        {
            Logger.Log("<-");
            ClickCloseButton();
            WaitCondition(()=>Convert.ToBoolean(GetJavaScriptExecutionResult("visReg != undefined")),60);
            Logger.Log("->");
        }

        public string GetEukaryoticCellsDescription()
        {
            Logger.Log("<-");
            _manager.GetNavigationHelper().OpenExhibitEukaryoticCells();
            Logger.Log("ExhibitEukaryotic Cell is opened");
            string description = GetText(By.XPath("//*[@id='vc']/*[@class='contentItemDescription']/div"));
            Logger.Log("-> description: " + description);
            return description;
        }

        public void OpenLifeTimeline()
        {
            Logger.Log("<-");
            _manager.GetNavigationHelper().OpenLifePage();
            WaitForElementIsDisplayed(By.Id("bc_link_t66"));
            WaitAnimation();
            Logger.Log("->");
        } 
        
        public void OpenHumanityTimeline()
        {
            Logger.Log("<-");
            _manager.GetNavigationHelper().OpenHumanityPage();
            WaitForElementIsDisplayed(By.Id("bc_link_t161"));
            WaitAnimation();
            Logger.Log("->");
        }

        public void OpenBceCeArea()
        {
            Logger.Log("<-");
            ExecuteJavaScript("controller.moveToVisible(new VisibleRegion2d(-2012.9408427494022, 222893683.28023896,0.001905849287056807),false)");
            WaitForElementIsDisplayed(By.Id("bc_link_t550"));
            WaitAnimation();
            Logger.Log("->");
        }

        public void OpenRomanHistoryTimeline()
        {
            Logger.Log("<-");
            _manager.GetNavigationHelper().NavigateToRomanHistoryTimeline();
            WaitForElementIsDisplayed(By.Id("bc_link_t44"));
            WaitAnimation();
            Logger.Log("->");
        }

        public string GetLastBreadcrumbs()
        {
            Logger.Log("<-");
            WaitAnimation();
            string result = GetText(By.XPath("//*[@id='breadCrumbsTable']/*/tr/td[last()]/div"));
            Logger.Log("-> Last Breadcrumbs: " + result);
            return result;
        }

        public void MoveMouseToCenter()
        {
            IWebElement timescale = FindElement(By.Id("axis"));
            MoveToElementAndClick(By.Id("axis"));
            var size = timescale.Size;
            //MoveToElementCoordinates(By.Id("axis"), size.Width/4, 0);
            //MoveToElementCoordinates(By.Id("axis"), 100, 0);
            //MoveToElementCoordinates(By.Id("axis"), 500, 0);
            //MoveToElementCoordinates(By.Id("axis"), 80, 0);
            //MoveToElementCoordinates(By.Id("axis"), 800, 0);
        }

        public void MoveMouseToLeft()
        {
            IWebElement timescale = FindElement(By.Id("axis"));
            double size = timescale.Size.Width;
            MoveToElementCoordinates(By.Id("axis"), (int)Math.Round(size/4), 0);
            
        }
    }
}