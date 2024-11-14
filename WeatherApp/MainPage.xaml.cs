using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WeatherApp {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        private readonly WeatherApiService _weatherService;
        WeatherData weatherData;

        public MainPage() {
            InitializeComponent();
            _weatherService = new WeatherApiService();
            this.NavigationCacheMode  = NavigationCacheMode.Required;
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e) {
            await GetWeatherData();
        }

        private async void CityTextBox_KeyDown(object sender, KeyRoutedEventArgs e) {
            if(e.Key == VirtualKey.Enter) {
                await GetWeatherData();
            }
        }

        private void ForecastItem_PointerPressed(object sender, PointerRoutedEventArgs e) {
            var gridItem = sender as Grid;
            var forecastData = gridItem.DataContext as ForecastItemViewModel;

            Frame.Navigate(typeof(ForecastDetails), forecastData);
        }

        private async Task GetWeatherData() {
            string city = CityTextBox.Text.Trim();
            if(string.IsNullOrWhiteSpace(city)) {
                ShowError("Please enter a city name");
                return;
            }

            try {
                LoadingRing.IsActive = true;
                ErrorInfoBar.IsOpen = false;
                CurrentWeatherPanel.Visibility = Visibility.Collapsed;
                ForecastHeader.Visibility = Visibility.Collapsed;

                int days = (int)DaysNumberBox.Value;
                weatherData = await _weatherService.GetWeatherDataAsync(city, days);

                Debug.WriteLine(days);
                LocationText.Text = $"{weatherData.Location.Name}, {weatherData.Location.Country}";
                CurrentTimeText.Text = $"As of {weatherData.Current.LastUpdated}";
                CurrentTemperatureText.Text = $"{weatherData.Current.TemperatureCelsius} C";
                CurrentConditionText.Text = weatherData.Current.Condition.Text;
                CurrentHumidityText.Text = $"Humidity: {weatherData.Current.Humidity}%";
                CurrentWindText.Text = $"Wind: {weatherData.Current.WindMph} mph {weatherData.Current.WindDirection}";
                CurrentPrecipText.Text = $"Precipitation: {weatherData.Current.PrecipitationMm} mm";
                CurrentFeelsLikeText.Text = $"Feels like: {weatherData.Current.FeelsLikeCelsius} C";
                Debug.WriteLine(weatherData.Forecast.ForecastDays[0].Hours[0].Time.ToString());

                var forecastItems = weatherData.Forecast.ForecastDays.Select((fd, index) => new ForecastItemViewModel {
                    Date = DateTime.Parse(weatherData.Forecast.ForecastDays[index].Hours.First().Time.ToString()).ToString("dd,MM,yyyy"),
                    Condition = fd.Day.Condition.Text,
                    ConditionIcon = "https:" + fd.Day.Condition.Icon,
                    MaxTemp = fd.Day.MaxTempCelsius,
                    MinTemp = fd.Day.MinTempCelsius,
                    TotalPrecip = fd.Day.TotalPrecipitationMm,
                    AvgHumidity = fd.Day.AverageHumidity,
                    MaxWind = fd.Day.MaxWindMph
                }).ToList();

                Debug.WriteLine(forecastItems.Count());
                Debug.WriteLine(forecastItems.First().ConditionIcon);
                ForecastRepeater.ItemsSource = forecastItems;

                CurrentWeatherPanel.Visibility = Visibility.Visible;
                ForecastHeader.Visibility = Visibility.Visible;
            } catch(Exception ex) {
                ShowError($"Error: {ex.Message}");
            } finally {
                LoadingRing.IsActive = false;
            }
        }

        private void ShowError(string message) {
            ErrorInfoBar.Message = message;
            ErrorInfoBar.IsOpen = true;
        }



        private void Grid_Tapped(object sender, TappedRoutedEventArgs e) {
            if(sender is FrameworkElement element && element.DataContext is ForecastItemViewModel clickedItem) {
                ForecastDay daPassare = weatherData.Forecast.ForecastDays.Find((q) => q.Hours.First().Time == clickedItem.Date);
                Debug.WriteLine($"Item clicked: {clickedItem.Date}");
                 Frame.Navigate(typeof(ForecastDetails), daPassare);
            }
        }
    }

    public class ForecastItemViewModel {
        public string Date { get; set; }
        public string Condition { get; set; }
        public string ConditionIcon { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public double TotalPrecip { get; set; }
        public int AvgHumidity { get; set; }
        public double MaxWind { get; set; }
    }


}
