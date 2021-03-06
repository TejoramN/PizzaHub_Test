
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class PizzaHubTestTest
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
    [Test]
    public void pizzaHubTest()
    {
        //Opening Website
        driver.Navigate().GoToUrl("https://localhost:7027/");

        //Setting Screen to full
        driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);

        //Seeing All Products
        driver.FindElement(By.LinkText("All Products")).Click();

        //Adding Veg Pizzas to Cart
        driver.FindElement(By.LinkText("Veg")).Click();
        driver.FindElement(By.CssSelector(".col-4:nth-child(2) .btn")).Click();
        driver.FindElement(By.CssSelector(".col-4:nth-child(3) .btn")).Click();

        //Adding Non-Veg Pizzas to Cart
        driver.FindElement(By.LinkText("Non_Veg")).Click();
        driver.FindElement(By.CssSelector(".col-4:nth-child(2) .btn")).Click();
        driver.FindElement(By.CssSelector(".col-4:nth-child(3) .btn")).Click();

        //Viewing Cart
        driver.FindElement(By.LinkText("View Cart")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(3) .btn-primary")).Click();
        driver.FindElement(By.LinkText("+")).Click();
        driver.FindElement(By.LinkText("-")).Click();

        //Removing from Cart
        driver.FindElement(By.LinkText("Remove")).Click();
        driver.FindElement(By.CssSelector(".btn-danger:nth-child(1)")).Click();
    }
}
