using System;
using System.Collections.Generic;
using System.Text;

namespace CPDWeatherApp
{
    public class BaseViewModel : ObservableObject
    {
        string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public BaseViewModel()
        {
        }
    }
}
