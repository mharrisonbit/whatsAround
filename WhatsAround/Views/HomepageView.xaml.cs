using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhatsAround.Views
{
    public partial class HomepageView : ContentPage
    {
        public HomepageView()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }
    }
}
