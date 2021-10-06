using System;
using System.Collections.Generic;
using System.Text;

namespace CPDWeatherApp
{
    public class WeatherObject
    {
        // Icon, Condition, DateTime/Timestamp, Temperature, Pressure, Humidity, Cloud Cover, Wind speed, wind direction,
        // Rain (last 3h)
        // Snow (last 3h)

        string _icon = string.Empty; //random string (for now)
        DateTime _timestamp;
        string _condition;
        string _temperature; // Celsius
        string _pressure; //hPa
        string _humidity; // 0-100%
        string _cloudCover; //0-100%
        string _windSpeed; //k/h bzw. kph
        string _windDirection; // kph
        string _rain3h; // mm
        string _snow3h; // mm

        // TO DO: Add robust error handling for real data from feeds. 
        // TO DO: Assign right types (double instead of string) and check input for errors/inconsistencies


        public WeatherObject()
        {
            Icon = "10d"; Timestamp = DateTime.Now; Condition = "100"; Temperature = "20 °C"; Pressure = "1029.23 hPa"; Humidity = "70%";
            CloudCover = "40%"; WindSpeed = "20 kph"; WindDirection = "456 kph"; Rain3h = "34 mm"; Snow3h = "24 mm";
        }

        public WeatherObject(string icon)
        {
            Icon = icon;
            Timestamp = DateTime.Now; Condition = "100"; Temperature = "20 °C"; Pressure = "1029.23 hPa"; Humidity = "70%";
            CloudCover = "40%"; WindSpeed = "20 kph"; WindDirection = "456 kph"; Rain3h = "34 mm"; Snow3h = "24 mm";
        }

        public WeatherObject(string icon, DateTime timestamp, string condition, string temperature, string pressure, string humidity, string cloudCover, string windSpeed, string windDirection, string rain3h, string snow3h)
        {
            Icon = icon; Timestamp = timestamp; Condition = condition; Temperature = temperature; Pressure = pressure; Humidity = humidity;
            CloudCover = cloudCover; WindSpeed = windSpeed; WindDirection = windDirection;  Rain3h = rain3h; Snow3h = snow3h;
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
            }
        }

        public string Condition
        {
            get { return _condition; }
            set
            {
                _condition = value;
            }
        }


        public DateTime Timestamp
        {
            get { return _timestamp; }
            set
            {
                _timestamp = value;
            }
        }

        public string Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
            }
        }

        public string Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
            }
        }

        public string Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
            }
        }

        public string CloudCover
        {
            get { return _cloudCover; }
            set
            {
                _cloudCover = value;
            }
        }

        public string WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                _windSpeed = value;
            }
        }

        public string WindDirection
        {
            get { return _windDirection; }
            set
            {
                _windDirection = value;
            }
        }

        public string Rain3h
        {
            get { return _rain3h; }
            set
            {
                _rain3h = value;
            }
        }

        public string Snow3h
        {
            get { return _snow3h; }
            set
            {
                _snow3h = value;
            }
        }



    }
}
