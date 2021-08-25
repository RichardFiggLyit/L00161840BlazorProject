using L00161840BlazorProject.Server;
using L00161840BlazorProject.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L00161840BlazorProject.Server.Controllers;
using Moq;
using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.Helpers;
using L00161840BlazorProject.Shared.DTOs;

namespace L00161840BlazorProject.UnitTests.HelperUnitTests
{
    [TestClass]
    public class AnnualLeaveHelperUnitTests
    {
        List<DateRangeDTO> dateRanges;

        [TestInitialize]
        public void TestSetUp()
        {

            dateRanges = new List<DateRangeDTO>()
            {
                new DateRangeDTO(new DateTime(2020,12, 24), new DateTime(2021,01, 02)),
                 new DateRangeDTO(new DateTime(2021,03, 01), new DateTime(2021,03, 05)),
                 new DateRangeDTO(new DateTime(2021,03, 08), new DateTime(2021,03, 10)),
            };

        }

        [TestMethod]
        public void CheckOverlaps_StartDateOverlaps_ReturnTrue()
        {
            //Arrange
            var startDate = new DateTime(2021, 03, 10);
            var endDate = new DateTime(2021, 03, 15);
            bool actualResult;
            bool expectedResult = true;

            //Act
            actualResult = AnnualLeaveHelper.CheckOverlaps(startDate, endDate, dateRanges);


            //Assert
            Assert.AreEqual(expectedResult, actualResult);


        }
        [TestMethod]
        public void CheckOverlaps_EndDateOverlaps_ReturnTrue()
        {
            //Arrange
            var startDate = new DateTime(2021, 02, 27);
            var endDate = new DateTime(2021, 03, 02);
            bool actualResult;
            bool expectedResult = true;

            //Act
            actualResult = AnnualLeaveHelper.CheckOverlaps(startDate, endDate, dateRanges);


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void CheckOverlaps_StartAndEndDateOverlaps_ReturnTrue()
        {
            //Arrange
            var startDate = new DateTime(2021, 03, 02);
            var endDate = new DateTime(2021, 03, 04);
            bool actualResult;
            bool expectedResult = true;

            //Act
            actualResult = AnnualLeaveHelper.CheckOverlaps(startDate, endDate, dateRanges);


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void CheckOverlaps_NoOverlaps_ReturnFalse()
        {
            //Arrange
            var startDate = new DateTime(2021, 04, 01);
            var endDate = new DateTime(2021, 04, 05);
            bool actualResult;
            bool expectedResult = false;

            //Act
            actualResult = AnnualLeaveHelper.CheckOverlaps(startDate, endDate, dateRanges);


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetWorkingDates_MondayToFriday_Matches()
        {

            //Arrange
            var startDate = new DateTime(2021, 08, 09);
            var endDate = new DateTime(2021, 08, 13);
            string actualResult;

            List<DateTime> expectedDates = new List<DateTime>() { new DateTime(2021, 08, 09), new DateTime(2021, 08, 10), 
                new DateTime(2021, 08, 11), new DateTime(2021, 08, 12), new DateTime(2021, 08, 13) };
            string expectedResult = expectedDates.ToStandardString();

            //Act
            var actualDates = AnnualLeaveHelper.GetWorkingDates(startDate, endDate);
            actualResult = actualDates.ToStandardString();


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetWorkingDates_MondayToSunday_Matches()
        {

            //Arrange
            var startDate = new DateTime(2021, 08, 09);
            var endDate = new DateTime(2021, 08, 15);
            string actualResult;

            List<DateTime> expectedDates = new List<DateTime>() { new DateTime(2021, 08, 09), new DateTime(2021, 08, 10),
                new DateTime(2021, 08, 11), new DateTime(2021, 08, 12), new DateTime(2021, 08, 13) };
            string expectedResult = expectedDates.ToStandardString();

            //Act
            var actualDates = AnnualLeaveHelper.GetWorkingDates(startDate, endDate);
            actualResult = actualDates.ToStandardString();


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetWorkingDates_MondayToFollowingSunday_Matches()
        {

            //Arrange
            var startDate = new DateTime(2021, 08, 09);
            var endDate = new DateTime(2021, 08, 22);
            string actualResult;

            var expectedDates = new List<DateTime>() { new DateTime(2021, 08, 09), new DateTime(2021, 08, 10),
                new DateTime(2021, 08, 11), new DateTime(2021, 08, 12), new DateTime(2021, 08, 13),new DateTime(2021, 08, 16),
                new DateTime(2021, 08, 17), new DateTime(2021, 08, 18), new DateTime(2021, 08, 19), new DateTime(2021, 08, 20)};
            string expectedResult = expectedDates.ToStandardString();

            //Act
            var actualDates = AnnualLeaveHelper.GetWorkingDates(startDate, endDate);
            actualResult = actualDates.ToStandardString();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Start date cannot be greater than end date.")]
        public void GetWorkingDates_StartBeforeEnd_Exception()
        {

            //Arrange
            var startDate = new DateTime(2021, 08, 09);
            var endDate = new DateTime(2021, 08, 08);

            //Act
            var actualDates = AnnualLeaveHelper.GetWorkingDates(startDate, endDate);

        }


        [TestMethod]
        public void GetTaxYear_Start2021End2021_OneYear()
        {

            //Arrange
            var startDate = new DateTime(2021, 08, 09);
            var endDate = new DateTime(2021, 08, 15);
            List<int> actualResult;

            List<int> expectedResult = new List<int>() { 2021 };

            //Act
            actualResult = DateHelpers.GetTaxYears(startDate, endDate);


            //Assert
            Assert.AreEqual(expectedResult.ToStandardString(), actualResult.ToStandardString());
            Console.WriteLine(actualResult.ToStandardString());
        }
        [TestMethod]
        public void GetTaxYear_Start2021End2022_TwoYear()
        {

            //Arrange
            var startDate = new DateTime(2021, 12, 24);
            var endDate = new DateTime(2022, 01, 06);
            List<int> actualResult;

            List<int> expectedResult = new List<int>() { 2021, 2022 };

            //Act
            actualResult = DateHelpers.GetTaxYears(startDate, endDate);


            //Assert
            Assert.AreEqual(expectedResult.ToStandardString(), actualResult.ToStandardString());
            Console.WriteLine(actualResult.ToStandardString());
        }
        [TestMethod]
        public void GetTaxYear_Start2021End2023_ThreeYears()
        {

            //Arrange
            var startDate = new DateTime(2021, 12, 24);
            var endDate = new DateTime(2023, 01, 06);
            List<int> actualResult;

            List<int> expectedResult = new List<int>() { 2021, 2022,2023 };

            //Act
            actualResult = DateHelpers.GetTaxYears(startDate, endDate);


            //Assert
            Assert.AreEqual(expectedResult.ToStandardString(), actualResult.ToStandardString());
            Console.WriteLine(actualResult.ToStandardString());
        }
        [TestMethod]
        public void GetStartOfDay_CorrectValue()
        {

            //Arrange
            var testDate = new DateTime(2021, 12, 24, 06, 06, 06);
            var expectedResult = new DateTime(2021, 12, 24, 00, 00, 00);
            DateTime actualResult;


            //Act
            actualResult = testDate.GetStartOfDay();


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

            [TestMethod]
            public void GetEndOfDay_CorrectValue()
            {

                //Arrange
                var testDate = new DateTime(2021, 12, 24, 06, 06, 06);
                var expectedResult = new DateTime(2021, 12, 24, 23, 59, 59);
                DateTime actualResult;


                //Act
                actualResult = testDate.GetEndOfDay();


                //Assert
                Assert.AreEqual(expectedResult, actualResult);

            }
        
    }
}
