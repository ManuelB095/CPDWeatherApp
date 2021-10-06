using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPDWeatherApp
{
    public interface INavigationService
    {
        Task NavigateToDetailsPage(WeatherObject item);
        Task NavigateBack();
    }
}
