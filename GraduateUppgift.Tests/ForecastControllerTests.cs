using GraduateUppgift.Controllers;
using GraduateUppgift.Core.Persistence;
using GraduateUppgift.Core.Persistence.Models;
using GraduateUppgift.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace GraduateUppgift.Tests
{
    [TestClass]
    public class ForecastControllerTests
    {
        private Mock<ForecastContext> ContextMock { get; set; }
        private Mock<IForecastService> ServiceMock { get; set; }
        private ForecastController Controller { get; set; }

        [TestInitialize]
        public void RunBeforeEachTest()
        {
            ContextMock = new Mock<ForecastContext>();
            ServiceMock = new Mock<IForecastService>();
            Controller = new ForecastController(ServiceMock.Object, ContextMock.Object);
        }

        [TestMethod]
        public void Given_City_When_GetForecast_Then_ForecastModelIsReturned()
        {
            // Arrange
            var country = new Country
            {
                namecity = "Stockholm",
                id = 1
            };

            var countries = (new Country[] { country }).AsQueryable();

            var mockSet = new Mock<DbSet<Country>>();
            mockSet.As<IQueryable<Country>>().Setup(s => s.Expression).Returns(countries.Expression);
            mockSet.As<IQueryable<Country>>().Setup(s => s.Provider).Returns(countries.Provider);

            ContextMock.Setup(c => c.Countries).Returns(mockSet.Object);

            // Act
            var result = Controller.Get(country.namecity).Result;
        }
    }
}
