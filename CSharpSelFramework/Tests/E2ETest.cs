﻿    using System;
    using System.Collections.Generic;
    using System.Linq;
using CSharpSelFramework.utilities;
using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using WebDriverManager.DriverConfigs.Impl;

    namespace SeleniumLearning
    {
        public class E2ETest:TestBase
        {

            
           
            

            [Test]
            public void EndToEndFlow()

            {

                String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
                driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
                driver.FindElement(By.Name("password")).SendKeys("learning");
                driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
                driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

               IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

                foreach( IWebElement product in products)
                {

                 if(expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))

                    {
                       product.FindElement(By.CssSelector(".card-footer button")).Click();
                    }
                 TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

                }
                 driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList <IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for(int i =0; i< checkoutCards.Count;i++)

            {
                actualProducts[i] = checkoutCards[i].Text;



            }
            Assert.AreEqual(expectedProducts, actualProducts);

            driver.FindElement(By.CssSelector(".btn-success")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();


            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
           String confirText= driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirText);


















        }
        }

    }
