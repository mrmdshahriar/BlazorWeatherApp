namespace BlazorWeatherApp.Models
{
    public class WeatherData
    {
        public string city { get; set; } = "";
        public double temperature { get; set; }
        public int humidity { get; set; }
        public int pressure { get; set; }
        public string weather { get; set; } = "";
        public double windSpeed { get; set; }
    }
}
