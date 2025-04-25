namespace BlazorWeatherApp.Models
{
    public class WeatherData
    {
        public string City { get; set; } = "";
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public string Weather { get; set; } = "";
        public double WindSpeed { get; set; }
    }
}
