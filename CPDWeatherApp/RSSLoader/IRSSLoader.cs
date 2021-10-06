using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CPDWeatherApp
{
    public interface IRSSLoader
    {
        void LoadData();
        void Reload();
        ObservableCollection<WeatherObject> GetWeatherData();
    }
}
