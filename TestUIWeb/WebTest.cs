using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace TestUIWeb
{
    [TestClass]
    public class WebTest
    {

        private static IWebDriver driver =  BrowserFactory.GetWebDriver(1);


        /// <summary>
        /// Beim Teststart
        /// </summary>
        /// <param name="ctx"></param>
        [AssemblyInitialize]
        public static void Initialize(TestContext ctx)
        {
            driver.Navigate().GoToUrl("http://localhost/BauernMultiplikation/index.html");
            // Beim ersten Aufruf dauert das länger.... 
            var ersterWert = Berechne(3, 7, 5);
            
        }

        /// <summary>
        /// Beim Testende
        /// </summary>
        [AssemblyCleanup]
        public static void CleanUp()
        {
            driver.Close();

        }

        #region TestFunktionen

        /// <summary>
        /// Teste drei Ergebnisse aus 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="erwartet"></param>
        [DataTestMethod]
        [DataRow(2, 8, (long)16)]
        [DataRow(4, 12, (long)48)]
        [DataRow(8, 2, (long)16)]
        public void TesteChromeBrowser(int? a, int? b, long? erwartet)
        {
            long? ergebnis = Berechne(a, b, 1);
            Assert.AreEqual(erwartet, ergebnis);


        }

        #endregion TestFunktionen

        #region Hilfsfunktionen


        /// <summary>
        /// Führe Seitencheck durch
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="waitSeconds"></param>
        /// <returns></returns>
        private static long? Berechne(int? a, int? b, int waitSeconds)
        {
            long? result = null;

            if (a.HasValue && b.HasValue)
            {
                //Find the Search text box UI Element
                IWebElement element = driver.FindElement(By.Id("ZahlA"));
                element.Clear();
                //Perform Ops
                element.SendKeys(a.ToString());
                
                //Find the Search text box UI Element
                element = driver.FindElement(By.Id("ZahlB"));
                element.Clear();
                //Perform Ops
                element.SendKeys(b.ToString());

                element = driver.FindElement(By.Id("Berechne"));

                element.Click();

                //driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);

                Thread.Sleep(waitSeconds * 1000);
                element = driver.FindElement(By.Id("Ergebnis"));

                var ergebnis = element.GetAttribute("value");

                long n;
                bool isNumeric = long.TryParse(ergebnis, out n);
                if (isNumeric) result = n;

            }


            return result;

        }


        #endregion Hilfsfunktionen 


    }
}
