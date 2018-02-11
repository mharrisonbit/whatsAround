using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WhatsAround.Models;
using Xamarin.Forms;

namespace WhatsAround.Views
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

#region parameters and variables

        string locationLabel;
        public string LocationLabel
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

#endregion

#region commands

        public Command GroundSpeedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await GetLocation();
                    await GetGroundSpeed();
                });
            }
        }

#endregion

        public HomePageViewModel()
		{
            Debug.WriteLine("this fired");
		}

#region methods

        private async Task GetLocation()
        {
            try
            {
				var position = new GetLocationModel();
				var gpsReturn = await position.Execute();
                LocationLabel = "gps location is" + Environment.NewLine + gpsReturn.Latitude + Environment.NewLine + gpsReturn.Longitude;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("ERROR... HomePageViewModel:GetLocation() {0}", ex));
            }
        }

        private async Task GetGroundSpeed()
        {
            var position = new GetLocationModel();
            var gpsReturn = await position.Execute();
            SpeedSpeedLabel = "Your ground speed is " + gpsReturn.Speed.ToString();
        }

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

#endregion

    }
}