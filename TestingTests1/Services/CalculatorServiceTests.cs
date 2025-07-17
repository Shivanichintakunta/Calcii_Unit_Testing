using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Testing.Data;
using Testing.Models;
using Testing.Services;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {


        private CalculatorDBContext GetInMemoryDbContext()
        {

            var options = new DbContextOptionsBuilder<CalculatorDBContext>()

                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            return new CalculatorDBContext(options);


        }

        [TestMethod]
        public async Task AddAsyncTest()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new CalculatorService(context);

            int operand1 = 20;
            int operand2 = 30;
            int expected = 50;

            // Act
            var resultEntity = await service.AddAsync(operand1, operand2);

            // Assert
            Assert.IsNotNull(resultEntity);
            Assert.AreEqual(expected, resultEntity.result);
        }

        [TestMethod()]
        public async Task SubAsyncTest()
        {
            var context = GetInMemoryDbContext();
            var service = new CalculatorService(context);

            int operand1 = 20;
            int operand2 = 30;
            int expected = -10;

            // Act
            var resultEntity = await service.SubAsync(operand1, operand2);

            // Assert
            Assert.IsNotNull(resultEntity);
            Assert.AreEqual(expected, resultEntity.result);
        }

        [TestMethod()]
        public async Task MulAsyncTest()
        {
            var context = GetInMemoryDbContext();
            var service = new CalculatorService(context);

            int operand1 = 20;
            int operand2 = 30;
            int expected = 600;

            // Act
            var resultEntity = await service.MulAsync(operand1, operand2);

            // Assert
            Assert.IsNotNull(resultEntity);
            Assert.AreEqual(expected, resultEntity.result);
        }

        [TestMethod()]
        public async Task DivAsyncTest()
        {
            var context = GetInMemoryDbContext();
            var service = new CalculatorService(context);

            int operand1 = 30;
            int operand2 = 10;
            int expected = 3;

            // Act
            var resultEntity = await service.DivAsync(operand1, operand2);

            // Assert
            Assert.IsNotNull(resultEntity);
            Assert.AreEqual(expected, resultEntity.result);
        }
        

    }
}
