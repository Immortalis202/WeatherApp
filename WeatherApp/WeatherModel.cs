using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using System.Text.Json.Serialization;

namespace WeatherApp {
    public class WeatherData {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public Current Current { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; }
    }

    public class Location {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("tz_id")]
        public string TimeZoneId { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
    }

    public class Current {
        [JsonPropertyName("last_updated_epoch")]
        public long LastUpdatedEpoch { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public double TemperatureCelsius { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("precip_mm")]
        public double PrecipitationMm { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int Cloud { get; set; }

        [JsonPropertyName("feelslike_c")]
        public double FeelsLikeCelsius { get; set; }

        [JsonPropertyName("windchill_c")]
        public double WindChillCelsius { get; set; }

        [JsonPropertyName("heatindex_c")]
        public double HeatIndexCelsius { get; set; }
    }

    public class Forecast {
        [JsonPropertyName("forecastday")]
        public List<ForecastDay> ForecastDays { get; set; }
    }

    public class ForecastDay {
        [JsonPropertyName("day")]
        public Day Day { get; set; }

        [JsonPropertyName("astro")]
        public Astro Astro { get; set; }

        [JsonPropertyName("hour")]
        public List<Hour> Hours { get; set; }
    }

    public class Day {
        [JsonPropertyName("maxtemp_c")]
        public double MaxTempCelsius { get; set; }

        [JsonPropertyName("mintemp_c")]
        public double MinTempCelsius { get; set; }

        [JsonPropertyName("avgtemp_c")]
        public double AvgTempCelsius { get; set; }

        [JsonPropertyName("maxwind_mph")]
        public double MaxWindMph { get; set; }

        [JsonPropertyName("totalprecip_mm")]
        public double TotalPrecipitationMm { get; set; }

        [JsonPropertyName("totalsnow_cm")]
        public double TotalSnowCm { get; set; }

        [JsonPropertyName("avgvis_km")]
        public double AverageVisibilityKm { get; set; }

        [JsonPropertyName("avghumidity")]
        public int AverageHumidity { get; set; }

        [JsonPropertyName("daily_will_it_rain")]
        public int WillItRain { get; set; }

        [JsonPropertyName("daily_chance_of_rain")]
        public int ChanceOfRain { get; set; }

        [JsonPropertyName("daily_will_it_snow")]
        public int WillItSnow { get; set; }

        [JsonPropertyName("daily_chance_of_snow")]
        public int ChanceOfSnow { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }
    }

    public class Astro {
        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("moonrise")]
        public string Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        public string Moonset { get; set; }

        [JsonPropertyName("moon_phase")]
        public string MoonPhase { get; set; }

        [JsonPropertyName("moon_illumination")]
        public int MoonIllumination { get; set; }

        [JsonPropertyName("is_moon_up")]
        public int IsMoonUp { get; set; }

        [JsonPropertyName("is_sun_up")]
        public int IsSunUp { get; set; }
    }

    public class Hour {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temp_c")]
        public double TemperatureCelsius { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("pressure_mb")]
        public double PressureMb { get; set; }

        [JsonPropertyName("precip_mm")]
        public double PrecipitationMm { get; set; }

        [JsonPropertyName("snow_cm")]
        public double SnowCm { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int Cloud { get; set; }

        [JsonPropertyName("feelslike_c")]
        public double FeelsLikeCelsius { get; set; }

        [JsonPropertyName("windchill_c")]
        public double WindChillCelsius { get; set; }

        [JsonPropertyName("heatindex_c")]
        public double HeatIndexCelsius { get; set; }

        [JsonPropertyName("dewpoint_c")]
        public double DewPointCelsius { get; set; }

        [JsonPropertyName("will_it_rain")]
        public int WillItRain { get; set; }

        [JsonPropertyName("chance_of_rain")]
        public int ChanceOfRain { get; set; }

        [JsonPropertyName("will_it_snow")]
        public int WillItSnow { get; set; }

        [JsonPropertyName("chance_of_snow")]
        public int ChanceOfSnow { get; set; }


        [JsonPropertyName("gust_mph")]
        public double GustMph { get; set; }

        [JsonPropertyName("uv")]
        public double UV { get; set; }

        
    }

    public class Condition {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
