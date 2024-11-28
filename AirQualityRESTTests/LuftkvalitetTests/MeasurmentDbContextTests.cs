using AirQualityREST.Luftkvalitet;
using Luftkvalitet;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirQualityRESTTests.LuftkvalitetTests
{
    [TestClass]
    public class MeasurmentDbContextTests
    {
        private MeasurmentsRepoDB? measurementRepo;

        [TestInitialize]
        public void Init()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeasurmentDbContext>();
            optionsBuilder.UseSqlServer(Secrets.ConnectionString);

            MeasurmentDbContext _dbContext = new(optionsBuilder.Options);

            _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Measurements");
            measurementRepo = new MeasurmentsRepoDB(_dbContext);
        }

        [TestMethod]
        public void NullTest()
        {
            //MeasurmentsRepoDB repo = new MeasurmentRepoDB();

            //Measurement? result = repo.GetById(1);

            //Assert.IsNull(result);
        }

    
        [TestMethod]
        public async Task GetAll_ShouldReturnEmptyList_WhenNoMeasurements()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeasurmentDbContext>()
                .UseSqlServer(Secrets.ConnectionString)
                .Options;

            using (var context = new MeasurmentDbContext(options))
            {
                var repository = new MeasurmentsRepoDB(context);

                // Act
                var result = await Task.Run(() => repository.GetAll());

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Count);
            }
        }
    }
}