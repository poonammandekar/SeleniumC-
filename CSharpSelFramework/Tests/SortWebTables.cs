﻿using System;
using System.Collections;
using System.Collections.Generic;
using CSharpSelFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SortWebTables:TestBase
    {
        

       

        [Test]

        public void SortTable()

        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            // step 1 - Get all veggie names into arraylist A
           IList <IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
                  

            }

            //step 2- Sort this arraylist  -A

            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            TestContext.Progress.WriteLine("After sorting");
            a.Sort();
            foreach( String element in a )
            {
                TestContext.Progress.WriteLine(element);
            }



            //step 3 - go and click column
            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();

            //step 4- Get all veggie names into arraylist B

            ArrayList b = new ArrayList();

            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);


            }

            // arraylist A to B = equal
            Assert.AreEqual(a, b);






        }
    }
}
