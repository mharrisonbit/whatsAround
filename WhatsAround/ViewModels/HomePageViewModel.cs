using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using WhatsAround.Models;

namespace WhatsAround.Views
{
    internal class HomePageViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

#region parameters and variables

        string homepageLabel;
        public string HomepageLabel
        {
            get { return homepageLabel; }
            set
            {
                homepageLabel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public HomePageViewModel()
		{
            GetLocation();
		}

        private async Task GetLocation()
        {
            var position = new GetLocationModel;
            position.Execute();

            HomepageLabel = string.Format("this is your current location {0} , {1}", position.Latitude, position.Longitude);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}