using Microsoft.VisualStudio.TestTools.UnitTesting;
using Luftkvalitet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace Lufktvalitet.Tests
{
    [TestClass()]
    public class MeasurementRepoTests
    {
        MeasurementRepo repo;
        [TestInitialize]
        public void Setup()
        {
            repo = new MeasurementRepo();
            Measurement meassurement1 = new Measurement() { Id = 1, CO2 = 1500, Humidity = 100, Location = "Her", Time = DateTime.Now.AddDays(-300) };
            Measurement meassurement2 = new Measurement() { Id = 2, CO2 = 700, Humidity = 56, Location = "Der", Time = DateTime.Now.AddDays(-100) };
            Measurement meassurement3 = new Measurement() { Id = 3, CO2 = 300, Humidity = 72, Location = "Et andet sted", Time = DateTime.Now.AddDays(-1000) };
            Measurement meassurement4 = new Measurement() { Id = 4, CO2 = 800, Humidity = 1, Location = "Et tredje sted", Time = DateTime.Now };
            repo.Add(meassurement1);
            repo.Add(meassurement2);
            repo.Add(meassurement3);
            repo.Add(meassurement4);

        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<Measurement> list = repo.GetAll("Her");
            Assert.AreEqual(1, list.Count);

            List<Measurement> list2 = repo.GetAll(dateTimeLower: DateTime.Now.AddDays(-301), dateTimeUpper: DateTime.Now);
            Assert.AreEqual(3, list2.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Measurement measurement1 = repo.GetById(1);
            Assert.AreEqual(measurement1.CO2, 1500);
        }

        [TestMethod()]
        public void AddTest()
        {
            repo.Add(new Measurement() { Id = 5, CO2 = 1500, Humidity = 100, Location = "Her2", Time = DateTime.Now.AddDays(-300) });
            List<Measurement> list = repo.GetAll();
            Assert.AreEqual(5, list.Count);
        }
    }
}