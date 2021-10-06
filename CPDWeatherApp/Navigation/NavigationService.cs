using CPDWeatherApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(NavigationService))]
namespace CPDWeatherApp
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public async Task NavigateToDetailsPage(WeatherObject item)
        {
            var currentPage = GetCurrentPage();
            await currentPage.Navigation.PushAsync(new DetailsPage(new DetailsPageViewModel(item)));
        }

        public async Task NavigateBack()
        {
            var currentPage = GetCurrentPage();
            await currentPage.Navigation.PopAsync();
        }

        private Page GetCurrentPage()
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault(); // Requires System.Linq!!
            return currentPage;
        }
    }
}
