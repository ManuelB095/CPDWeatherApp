using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace CPDWeatherApp
{
    public class DetailsPageViewModel : BaseViewModel
    {
        WeatherObject _currentObject;

        public WeatherObject CurrentObject
        {
            get { return _currentObject; }
            set { SetProperty(ref _currentObject, value); }
        }
        
        public Command NavigateBackCommand { get; set; }
       
        public DetailsPageViewModel(WeatherObject item)
        {
            CurrentObject = item;
            Title = "DetailsPage";
            NavigateBackCommand = new Command(ExecuteNavigateBackCommand);
        }

        void ExecuteNavigateBackCommand()
        {
            DependencyService.Get<INavigationService>().NavigateToDetailsPage(CurrentObject);
        }
    }
}
