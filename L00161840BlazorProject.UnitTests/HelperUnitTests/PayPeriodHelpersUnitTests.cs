using L00161840BlazorProject.Shared.Entities;
using L00161840BlazorProject.Shared.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Claims;

namespace L00161840BlazorProject.HelperUnitTests
{
    [TestClass]
    public class PayPeriodHelpersUnitTests
    {
        [TestMethod]
        public void SuggestedMaxPayDate_MonthlyJune_CorrectValue()
        {
            Period period = Period.Monthly;
            int taxYear = 2021;
            int taxPeriod = 6;


            DateTime actualResult;
            DateTime expectedResult = new DateTime(2021, 06, 30);

            actualResult = PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void SuggestedMaxPayDate_Weekly32_CorrectValue()
        {
            Period period = Period.Weekly;
            int taxYear = 2021;
            int taxPeriod = 32;


            DateTime actualResult;
            DateTime expectedResult = new DateTime(2021, 08, 12);

            actualResult = PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);
            Assert.AreEqual(expectedResult, actualResult);
            Console.WriteLine(actualResult.ToShortDateString());
        }
        [TestMethod]
        public void SuggestedMaxPayDate_Fortnightly16_CorrectValue()
        {
            Period period = Period.Fortnightly;
            int taxYear = 2021;
            int taxPeriod = 16;


            DateTime actualResult;
            DateTime expectedResult = new DateTime(2021, 08, 12);

            actualResult = PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);
            Assert.AreEqual(expectedResult, actualResult);
            Console.WriteLine(actualResult.ToShortDateString());
        }
        [TestMethod]
        public void SuggestedMaxPayDate_FourWeekly8_CorrectValue()
        {
            Period period = Period.FourWeekly;
            int taxYear = 2021;
            int taxPeriod = 8;


            DateTime actualResult;
            DateTime expectedResult = new DateTime(2021, 08, 12);

            actualResult = PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);
            Assert.AreEqual(expectedResult, actualResult);
            Console.WriteLine(actualResult.ToShortDateString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
    "Tax Period 54 is greater than maximum number of tax periods in a year!")]
        public void SuggestedMaxPayDate_Weekly54_Exception()
        {
            Period period = Period.Weekly;
            int taxYear = 2021;
            int taxPeriod = 54;
            PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
"Tax Period 13 is greater than maximum number of tax periods in a year!")]
        public void SuggestedMaxPayDate_Monthly13_Exception()
        {
            Period period = Period.Monthly;
            int taxYear = 2021;
            int taxPeriod = 13;
            PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);

        }
        [TestMethod]

        public void SuggestedMaxPayDate_Weekly53_EndOfYear()
        {
            Period period = Period.Weekly;
            int taxYear = 2021;
            int taxPeriod = 53;

            DateTime actualResult;
            DateTime expectedResult = new DateTime(2021, 12, 31);

            actualResult = PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);
            Assert.AreEqual(expectedResult, actualResult);
            Console.WriteLine(actualResult.ToShortDateString());

        }
        [TestMethod]

        public void SuggestedMaxPayDate_Fortnightly27_EndOfYear()
        {
            Period period = Period.Fortnightly;
            int taxYear = 2021;
            int taxPeriod = 27;

            DateTime actualResult;
            DateTime expectedResult = new DateTime(2021, 12, 31);

            actualResult = PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);
            Assert.AreEqual(expectedResult, actualResult);
            Console.WriteLine(actualResult.ToShortDateString());

        }
        [TestMethod]

        public void SuggestedMaxPayDate_4Weekly14_EndOfYear()
        {
            Period period = Period.FourWeekly;
            int taxYear = 2021;
            int taxPeriod = 14;

            DateTime actualResult;
            DateTime expectedResult = new DateTime(2021, 12, 31);

            actualResult = PayPeriodHelper.SuggestedMaxPayDate(taxYear, taxPeriod, period);
            Assert.AreEqual(expectedResult, actualResult);
            Console.WriteLine(actualResult.ToShortDateString());

        }
    }
}
