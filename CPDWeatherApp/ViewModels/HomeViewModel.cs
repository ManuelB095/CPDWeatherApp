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
            WeatherObjects = new ObservableCollection<WeatherObject>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());
            ItemClickCommand = new Command(async (item) => await ExecuteItemClickedCommand(item));
            LoadDataCommand.Execute("");

        }

        private async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                WeatherDataService dataServ = new WeatherDataService();
                var WeatherObjectsFromJSON = await dataServ.GetWeatherObjectAsync();
                WeatherObjects.Clear();
                foreach (var weatherObject in WeatherObjectsFromJSON)
                {
                    WeatherObjects.Add(weatherObject);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: {0}", ex.Message);
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
