using L00161840BlazorProject.Shared.Entities;
using L00161840BlazorProject.Shared.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Claims;

namespace L00161840BlazorProject.HelperUnitTests
{
    [TestClass]
    public class HelpersUnitTests
    {
        [TestMethod]
        public void ToEuro_PositiveNumber_ValidOutput()
        {
            double amount = 12554.9756;

            string actualResult;
            string expectedResult = "€12,554.98";
            actualResult = amount.ToEuro();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ToEuro_NegativeNumber_ValidOutput()
        {
            double amount = -12554.9756;

            string actualResult;
            string expectedResult = "-€12,554.98";
            actualResult = amount.ToEuro();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsAdmin_IsAnAdmin_True()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Role, "Admin"),
            }, "mock"));

            bool actualResult;
            bool expectedResult = true;
            
            actualResult = user.IsAdmin();
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void IsAdmin_IsNotAnAdmin_False()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
            }, "mock"));

            bool actualResult;
            bool expectedResult = false;

            actualResult = user.IsAdmin();
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void IsAdmin_Misspelt_False()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Role, "Adminstator"),
            }, "mock"));

            bool actualResult;
            bool expectedResult = false;

            actualResult = user.IsAdmin();
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void EmployeeId_NotANumber_Zero()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("Employee", "not an employee"),
            }, "mock"));

            int actualResult;
            int expectedResult = 0;

            actualResult = user.EmployeeId();
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void EmployeeId_ValidNumber_One()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("Employee", "1"),
            }, "mock"));

            int actualResult;
            int expectedResult = 1;

            actualResult = user.EmployeeId();
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void EmployeeId_NotAnEmployee_Zero()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
            }, "mock"));

            int actualResult;
            int expectedResult = 0;

            actualResult = user.EmployeeId();
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
