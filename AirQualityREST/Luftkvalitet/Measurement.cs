namespace Luftkvalitet
{
    public class Measurement
    {
        public int Id { get; set; }
        public string? Location { get; set; }
        public int Humidity { get; set; }
        public int CO2 { get; set; }
        public DateTime Time { get; set; }
        public int Temperature { get; set; }

        public Measurement()
        {
            
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Location))
            {
                throw new ArgumentNullException("Location is required");
            }
            if (Humidity <= 0 || Humidity >= 100)
            {
                throw new ArgumentOutOfRangeException("Humidity must be between 0 and 100");
            }
            if (CO2 <= 0)
            {
                throw new ArgumentOutOfRangeException("CO2 must be a positive number");
            }
            //if (Time == default)
            //{
            //    throw new System.Exception("Time is required");
            //}
        }
    }
}
