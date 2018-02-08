using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Geolocator;

namespace WhatsAround.Views
{
    internal class HomePageViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

#region parameters and veriables

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
            var currentLocation = CrossGeolocator.Current;
            currentLocation.DesiredAccuracy = 25;
            homepageLabel = currentLocation.GetPositionAsync().ToString();
		}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}