using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirQualityREST.Luftkvalitet;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Luftkvalitet;
using Microsoft.AspNetCore.Routing;

namespace AirQualityREST.Tests
{
    [TestClass]
    public class MeasurmentsRepoDBTests
    {
        private MeasurmentDbContext _context;
        private MeasurmentsRepoDB meassurements;

        [TestInitialize]
        public void Setup()
        {
            // Brug din faktiske SQL Server forbindelse
            var options = new DbContextOptionsBuilder<MeasurmentDbContext>()
                .UseSqlServer(Secrets.ConnectionStringTest)
                .Options;

            _context = new MeasurmentDbContext(options);

            // Ryd databasen før hver test
            _context.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Measurements");

            meassurements = new MeasurmentsRepoDB(_context);

            // Tilføj nogle testdata
            _context.Measurements.AddRange(
                 new Measurement { CO2 = 1500, Humidity = 100, Temperature = 22, Location = "Her", Time = DateTime.Now.AddDays(-300) },
                 new Measurement { CO2 = 700, Humidity = 56, Temperature = 18, Location = "Der", Time = DateTime.Now.AddDays(-100) },
                 new Measurement { CO2 = 300, Humidity = 72, Temperature = 19, Location = "Et andet sted", Time = DateTime.Now.AddDays(-1000) },
                 new Measurement { CO2 = 800, Humidity = 1, Temperature = 21, Location = "Et tredje sted", Time = DateTime.Now },
                 new Measurement { CO2 = 800, Humidity = 1, Temperature = 21, Location = "Et tredje sted", Time = DateTime.Now}

            );
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddMeasurement()
        {
            // Arrange
            var measurement = new Measurement
            {
                CO2 = 400,
                Humidity = 50,
                Temperature = 20,
                Location = "Test Location",
                Time = DateTime.Now
            };

            // Act
            var addedMeasurement = meassurements.Add(measurement);

            // Assert
            Assert.IsNotNull(addedMeasurement);
            Assert.AreNotEqual(0, addedMeasurement.Id); // Id should be set after adding
            Assert.AreEqual(measurement.CO2, addedMeasurement.CO2);
            Assert.AreEqual(measurement.Humidity, addedMeasurement.Humidity);
            Assert.AreEqual(measurement.Temperature, addedMeasurement.Temperature);
            Assert.AreEqual(measurement.Location, addedMeasurement.Location);
        }

        [TestMethod]
        public void DeleteId()
        {
            // Arrange
            var idToDelete = 1; // Assuming seeded data contains an item with Id = 1

            // Act
            var deletedMeasurement = meassurements.Delete(idToDelete);

            // Assert
            Assert.IsNotNull(deletedMeasurement);
            Assert.AreEqual(idToDelete, deletedMeasurement.Id);

            var retrievedMeasurement = _context.Measurements.FirstOrDefault(m => m.Id == idToDelete);
            Assert.IsNull(retrievedMeasurement); // Ensure it's removed from the database
        }

        [TestMethod]
        public void DeleteNullId()
        {
            // Arrange
            var nonExistentId = 999;

            // Act
            var result = meassurements.Delete(nonExistentId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            // Arrange
            var existingId = 2; // Assuming seeded data contains an item with Id = 2

            // Act
            var measurement = meassurements.GetById(existingId);

            // Assert
            Assert.IsNotNull(measurement);
            Assert.AreEqual(existingId, measurement.Id);
        }

        [TestMethod]
        public void GetLatestIdTest()
        {
            // Act
            var latestMeasurement = meassurements.GetLatestId();
            // Assert
            Assert.IsNotNull(latestMeasurement);
            Assert.AreEqual(meassurements.Count, latestMeasurement.Id); // Assuming seeded data contains an item with Id = 4
        }

        [TestMethod]
        public void GetByIdNullId()
        {
            // Arrange
            var nonExistentId = 999;

            // Act
            var measurement = meassurements.GetById(nonExistentId);

            // Assert
            Assert.IsNull(measurement);
        }

        [TestMethod]
        public void GetAllTest()
        {
            // Act
            var measurements = meassurements.GetAll();

            // Assert
            Assert.IsNotNull(measurements);
            Assert.AreEqual(5, measurements.Count); // Assuming 5 items were seeded
        }

        [TestMethod]
        public void GetAllFilterTest()
        {
            
            List<Measurement> measurements = meassurements.GetAll(dateTimeLower: new DateTime(2024,12,9));
            Assert.AreEqual(2, measurements.Count);


        }

        [TestMethod]
        public void GetAllFilterByDateTest()
        {
            // Arrange
            var dateTimeLower = new DateTime(2024, 12, 9);
            var dateTimeUpper = new DateTime(2024, 12, 5);

            // Act
            List<Measurement> measurements = meassurements.GetAll(dateTimeLower: dateTimeLower, dateTimeUpper: dateTimeUpper);

            // Assert
            Assert.IsNotNull(measurements);
            Assert.IsTrue(measurements.All(m => m.Time >= dateTimeLower && m.Time <= dateTimeUpper));
        }


        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }
    }
}
