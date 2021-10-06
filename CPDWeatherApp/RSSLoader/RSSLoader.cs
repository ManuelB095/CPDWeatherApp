using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CPDWeatherApp
{
    public class RSSLoader : IRSSLoader
    {
        ObservableCollection<WeatherObject> _dummyData;

        public ObservableCollection<WeatherObject> DummyData
        {
            get { return _dummyData; }
            private set
            {
                _dummyData = value;
            }
        }

        public RSSLoader()
        {
            DummyData = new ObservableCollection<WeatherObject>();
            LoadData();
        }

        public ObservableCollection<WeatherObject> GetWeatherData()
        {
            return DummyData;
        }

        public void LoadData()
        {
            // For now, till RSS Reader is established
            DummyData.Clear();
            for (int i = 0; i < 20; ++i)
            {
                DummyData.Add(new WeatherObject());
            }
        }

        public void Reload()
        {
            LoadData();
        }
            

    }
}
