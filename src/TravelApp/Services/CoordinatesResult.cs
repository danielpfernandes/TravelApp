namespace TravelApp.Services
{
    public class CoordinatesResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}