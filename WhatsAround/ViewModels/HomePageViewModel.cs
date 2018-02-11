using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using WhatsAround.Models;
using Xamarin.Forms;

namespace WhatsAround.Views
{
    internal class HomePageViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

#region parameters and variables

        string homepageLabel;
        public Position locationAndSpeed;

        string LocationLabel;
        public string locationLabel
        {
            get { return locationLabel; }
            set
            {
                locationLabel = value;
                OnPropertyChanged();
            }
        }

        string speedSpeedLabel;
        public string SpeedSpeedLabel 
        {
            get { return speedSpeedLabel; }
            set
            {
                speedSpeedLabel = value;
                OnPropertyChanged();
            }
        }

        public Command GroundSpeedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    GetLocation();
                });
            }
        }


        #endregion

        public HomePageViewModel()
		{
            Debug.WriteLine("this fired");
		}

        private async Task GetLocation()
        {
            var position = new GetLocationModel();
            var gpsReturn = await position.Execute();
            locationLabel = "gps location is " + gpsReturn.Latitude + " , " + gpsReturn.Longitude;


        }

        private async Task GetGroundSpeed()
        {
            var position = new GetLocationModel();
            var gpsReturn = await position.Execute();
            speedSpeedLabel = gpsReturn.Speed.ToString();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}