﻿using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace WhatsAround.Models
{
    public class GetLocationModel
    {

        public Task<Position> Execute()
        {
            var test = GetLocationAsync();
            return test;
        }

        private async Task<Position> GetLocationAsync()
        {
            var location = CrossGeolocator.Current;
            location.DesiredAccuracy = 25;
            var position = await location.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
            return position;
        }
    }
}
