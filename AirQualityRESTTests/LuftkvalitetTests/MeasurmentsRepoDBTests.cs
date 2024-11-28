//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Microsoft.EntityFrameworkCore;
//using AirQualityREST.Luftkvalitet;
//using System.Collections.Generic;
//using System.Linq;

//namespace AirQualityRESTTests.LuftkvalitetTests
//{
//    [TestClass]
//    public class MeasurmentsRepoDBTests
//    {
//        private MeasurmentDbContext _context;
//        private MeasurmentsRepoDB _repo;

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            // Opretter en in-memory database
//            var options = new DbContextOptionsBuilder<MeasurmentDbContext>()
//                .Options;

//            _context = new MeasurmentDbContext(options);
//            _repo = new MeasurmentsRepoDB(_context);

//            // Rydder databasen før hver test
//            _context.Database.EnsureDeleted();
//            _context.Database.EnsureCreated();
//        }

//        [TestMethod]
//        public void Add_Should_AddMeasurement_And_ReturnIt()
//        {
//            // Arrange
//            var measurement = new Measurement { Value = 42.5, Unit = "ppm" };

//            // Act
//            var result = _repo.add(measurement);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(42.5, result.Value);
//            Assert.AreEqual(1, _repo.Count);
//        }

//        [TestMethod]
//        public void Delete_Should_RemoveMeasurement_And_ReturnIt()
//        {
//            // Arrange
//            var measurement = new Measurement { Value = 42.5, Unit = "ppm" };
//            var addedMeasurement = _repo.add(measurement);

//            // Act
//            var result = _repo.Delete(addedMeasurement.Id);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(addedMeasurement.Id, result.Id);
//            Assert.AreEqual(0, _repo.Count);
//        }

//        [TestMethod]
//        public void GetById_Should_ReturnMeasurement_WhenExists()
//        {
//            // Arrange
//            var measurement = new Measurement { Value = 42.5, Unit = "ppm" };
//            var addedMeasurement = _repo.add(measurement);

//            // Act
//            var result = _repo.GetById(addedMeasurement.Id);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(addedMeasurement.Id, result.Id);
//        }

//        [TestMethod]
//        public void GetById_Should_ReturnNull_WhenDoesNotExist()
//        {
//            // Act
//            var result = _repo.GetById(1);

//            // Assert
//            Assert.IsNull(result);
//        }

//        [TestMethod]
//        public void GetAll_Should_ReturnAllMeasurements()
//        {
//            // Arrange
//            var measurement1 = new Measurement { Value = 42.5, Unit = "ppm" };
//            var measurement2 = new Measurement { Value = 30.2, Unit = "ppm" };
//            _repo.add(measurement1);
//            _repo.add(measurement2);

//            // Act
//            var result = _repo.GetAll();

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(2, result.Count);
//        }
//    }
//}