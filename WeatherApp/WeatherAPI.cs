using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.UI.Xaml.Controls;
using System.Net.Http.Json;
using WeatherApp;
using System.Diagnostics;

namespace WeatherApp {
    public class WeatherApiService {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://api.weatherapi.com/v1";
        private const string ApiKey = "6b46a1ed09a845f1a4c130259242510";

        public WeatherApiService() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<WeatherData> GetWeatherDataAsync(string city, int days = 7) {
            try {
                string url = $"{BaseUrl}/forecast.json?key={ApiKey}&q={Uri.EscapeDataString(city)}&days={days}&aqi=no";
                Debug.WriteLine(url);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
                return weatherData;
            } catch(HttpRequestException ex) {
                throw new Exception($"Error fetching weather data: {ex.Message}");
            } catch(JsonException ex) {
                throw new Exception($"Error parsing weather data: {ex.Message}");
            }
        }
    }
}
