using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftkvalitet
{
    public class MeasurementRepo
    {
        List<Measurement> meassurements;
        public MeasurementRepo()
        {
            meassurements = new List<Measurement>();
        }

        public List<Measurement> GetAll(string? location = null, DateTime? dateTimeLower = null, DateTime? dateTimeUpper = null)
        {
            List<Measurement> list = new List<Measurement>(meassurements);
            if (location != null)
            {
                list = list.FindAll(m => m.Location == location);
            }
            if (dateTimeLower != null && dateTimeUpper != null)
            {
                list = list.FindAll(m => m.Time >= dateTimeLower);
                list = list.FindAll(m => m.Time <= dateTimeUpper);
            }
            return list;
        }
        public Measurement GetById(int id)
        {
            return meassurements.Find(m => m.Id == id);
        }
        public void Add(Measurement meassurement)
        {
            meassurement.Validate();
            meassurements.Add(meassurement);
        }
    }
}
