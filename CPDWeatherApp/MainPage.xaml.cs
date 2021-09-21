using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPDWeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
            int firstValFromEntry = 0; int secValFromEntry = 0;
            
            if(Int32.TryParse(firstVal.Text, out firstValFromEntry) && Int32.TryParse(secondVal.Text, out secValFromEntry))
            {
                // User Input Correct: Show result
                Output.Text = Convert.ToString(firstValFromEntry + secValFromEntry);
            }
            else // User input incorrect: Display information for correct input
            {
                Output.Text = "Invalid input! Please type only whole numbers from 0-9!";
            }
        }

        private void mySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            lblSliderOutput.Text = Convert.ToString(value);
        }
    }
}
