//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using AirQualityREST.Luftkvalitet;
//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//namespace AirQualityREST.Tests
//{
//    [TestClass]
//    public class MeasurmentsRepoDBTests
//    {
//        private MeasurmentDbContext _context;
//        private MeasurmentsRepoDB _repo;

//        [TestInitialize]
//        public void Setup()
//        {
//            // Create in-memory database for testing
//            var options = new DbContextOptionsBuilder<MeasurmentDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDatabase")
//                .Options;

//            _context = new MeasurmentDbContext(options);
//            _repo = new MeasurmentsRepoDB(_context);

//            // Seed test data
//            _context.Measurements.AddRange(
//                new Measurement { Id = 1, CO2 = 1500, Humidity = 100, Location = "Her", Time = DateTime.Now.AddDays(-300) },
//                new Measurement { Id = 2, CO2 = 700, Humidity = 56, Location = "Der", Time = DateTime.Now.AddDays(-100) },
//                new Measurement { Id = 3, CO2 = 300, Humidity = 72, Location = "Et andet sted", Time = DateTime.Now.AddDays(-1000) },
//                new Measurement { Id = 4, CO2 = 800, Humidity = 1, Location = "Et tredje sted", Time = DateTime.Now }
//            );
//            _context.SaveChanges();
//        }

//        [TestMethod]
//        public void GetAllTest()
//        {
//            List<Measurement> measurements = _repo.GetAll();
//            Assert.AreEqual(4, measurements.Count);
//        }

//        [TestMethod]
//        public void GetByIdTest()
//        {
//            Measurement measurement = _repo.GetById(1);
//            Assert.IsNotNull(measurement);
//            Assert.AreEqual(1500, measurement.CO2);
//        }

//        [TestMethod]
//        public void AddTest()
//        {
//            Measurement newMeasurement = new Measurement { CO2 = 1200, Humidity = 80, Location = "Ny lokation", Time = DateTime.Now };
//            _repo.add(newMeasurement);

//            List<Measurement> measurements = _repo.GetAll();
//            Assert.AreEqual(5, measurements.Count);
//            Assert.AreEqual("Ny lokation", measurements.Last().Location);
//        }

//        [TestMethod]
//        public void DeleteTest()
//        {
//            Measurement deletedMeasurement = _repo.Delete(1);

//            Assert.IsNotNull(deletedMeasurement);
//            Assert.AreEqual(1500, deletedMeasurement.CO2);

//            Measurement measurement = _repo.GetById(1);
//            Assert.IsNull(measurement);

//            List<Measurement> measurements = _repo.GetAll();
//            Assert.AreEqual(3, measurements.Count);
//        }

//        [TestCleanup]
//        public void Cleanup()
//        {
//            _context.Dispose();
//        }
//    }
//}
