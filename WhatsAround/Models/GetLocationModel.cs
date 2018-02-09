using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace WhatsAround.Models
{
    public class GetLocationModel
    {
        private static Position position;

        public Position Execute()
        {
            await GetLocationAsync();
        }

        private async Position GetLocationAsync()
        {
            var location = CrossGeolocator.Current;
            location.DesiredAccuracy = 25;
            position = await location.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
            return position;
        }
    }
}
