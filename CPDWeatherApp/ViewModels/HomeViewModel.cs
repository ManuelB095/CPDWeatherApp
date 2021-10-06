using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPDWeatherApp
{
    public class HomeViewModel : BaseViewModel
    {
        IRSSLoader _rssLoader;

        public IRSSLoader RssLoader
        {
            get { return _rssLoader; }
            set
            {
                _rssLoader = value;
            }
        }

        ObservableCollection<WeatherObject> _weatherObjects;
        public ObservableCollection<WeatherObject> WeatherObjects
        {
            get { return _weatherObjects; }
            set { SetProperty(ref _weatherObjects, value); }
        }

        bool _busy = false;
        public bool IsBusy
        {
            get { return _busy; }
            set { SetProperty(ref _busy, value); }
        }

        public Command LoadDataCommand { get; set; }
        public Command ItemClickCommand { get; set; }

        public HomeViewModel()
        {
            Title = "Homework2";
            RssLoader = new RSSLoader(); RssLoader.LoadData();
            WeatherObjects = RssLoader.GetWeatherData();
            LoadDataCommand = new Command(ExecuteLoadDataCommand);
            ItemClickCommand = new Command(async (item) => await ExecuteItemClickedCommand(item));
        }

        void ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                RssLoader.Reload();
                WeatherObjects = RssLoader.GetWeatherData();
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteItemClickedCommand(object item)
        {
            if (item is WeatherObject weatherItem)
            {
                await DependencyService.Get<INavigationService>().NavigateToDetailsPage(weatherItem);
            }
        }
    }
}
