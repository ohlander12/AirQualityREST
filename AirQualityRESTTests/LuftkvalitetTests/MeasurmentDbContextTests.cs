using AirQualityREST;
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
    }
}