﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CPDWeatherApp
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableObject() 
        {

        }

        protected bool SetProperty<T>(
           ref T backingStore, T value,
           [CallerMemberName] string propertyName = ""
           )
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed != null)
                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
