using Luftkvalitet;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirQualityREST.Luftkvalitet
{
    public class MeasurmentsRepoDB
    {

        private readonly MeasurmentDbContext _context;

        public MeasurmentsRepoDB(MeasurmentDbContext dbContext)
        {
            _context = dbContext;
        }

        public int Count { get { return _context.Measurements.ToList().Count; } }


        public Measurement Add(Measurement measurement)
        {
            measurement.Validate();
            measurement.Id = 0;
            measurement.Time = System.DateTime.Now;
            _context.Measurements.Add(measurement);
            _context.SaveChanges();
            return measurement;
        }

        public Measurement Delete(int id)
        {
            Measurement? measurement = GetById(id);
            if (measurement != null)
            {
                _context.Measurements.Remove(measurement);
                _context.SaveChanges();
                return measurement;
            }
            return null;

        }

        public Measurement? GetById(int id)
        {
            return _context.Measurements.FirstOrDefault(x => x.Id == id);
        }

        public List<Measurement> GetAll(string? location = null, DateTime? dateTimeLower = null, DateTime? dateTimeUpper = null)
        {
            List<Measurement> measurementList = _context.Measurements.ToList();
            if(location != null)
            {
                measurementList = measurementList.FindAll(m => m.Location == location);
            }
            if (dateTimeLower != null)
            {
                measurementList = measurementList.FindAll(m => m.Time >= dateTimeLower);
            }
            if (dateTimeUpper != null)
            {
                measurementList = measurementList.FindAll(m => m.Time <= dateTimeUpper);

            }
            
            return measurementList;
        }


    }
}
