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
using L00161840BlazorProject.Client.Repository;

namespace L00161840BlazorProject.UnitTests.ControllerUnitTests
{
    [TestClass]
    public class CompaniesControllerUnitTest
    {
        ApplicationDbContext context;
        CompaniesController companiesController;
        [TestInitialize]
        public void  TestSetUp()
        {
            var dbContextOtions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(
                connectionString: "server=LAPTOP-6M8Q3DQJ\\SQLEXPRESS;Database=PayrollPortalTesting;Trusted_Connection=True");
            context = new ApplicationDbContext(dbContextOtions.Options);
            context.Database.EnsureCreated();
            companiesController = new CompaniesController(context);

        }

        [TestMethod]
        public async Task Get_GetNewCompany_ReturnedCompany()
        {
            var client = new Mock<ICompanyRepository>();
            
            Company expectedResult = new Company();
            Company actualResult;
            expectedResult.Name = "Test";
            expectedResult.TaxReference = "123456AB";
            await companiesController.Post(expectedResult);

            var actionResult = await companiesController.Get();
            actualResult = actionResult.Value;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCleanup]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }
    }
}
