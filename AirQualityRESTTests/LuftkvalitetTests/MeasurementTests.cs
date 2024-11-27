using Microsoft.VisualStudio.TestTools.UnitTesting;
using Luftkvalitet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftkvalitet.Tests
{
    [TestClass()]
    public class MeasurementTests
    {
        Measurement meassurement1;
        Measurement meassurement2;
        Measurement meassurement3;
        Measurement meassurement4;
        Measurement meassurement5;
        Measurement meassurement6;

        [TestInitialize]
        public void Setup()
        {
            meassurement1 = new Measurement() { Id = 1, CO2 = 0, Humidity = 100, Location = "Her", Time = DateTime.Now };
            meassurement2 = new Measurement() { Id = 2, CO2 = -1, Humidity = 69, Location = "Her", Time = DateTime.Now };
            meassurement3 = new Measurement() { Id = 3, CO2 = 650, Humidity = 101, Location = "Her", Time = DateTime.Now };
            meassurement4 = new Measurement() { Id = 4, CO2 = 650, Humidity = 100, Time = DateTime.Now };
            meassurement5 = new Measurement() { Id = 5, CO2 = 650, Humidity = 100, Location = "Her" };
            meassurement6 = new Measurement() { Id = 6, CO2 = 650, Humidity = -1, Location = "Her", Time = DateTime.Now };

        }
        [TestMethod()]
        public void ValidateTest()
        {
            meassurement1.Validate();
            Assert.ThrowsException<Exception>(() => meassurement2.Validate());
            Assert.ThrowsException<Exception>(() => meassurement3.Validate());
            Assert.ThrowsException<Exception>(() => meassurement4.Validate());
            Assert.ThrowsException<Exception>(() => meassurement5.Validate());
            Assert.ThrowsException<Exception>(() => meassurement6.Validate());
        }
    }
}