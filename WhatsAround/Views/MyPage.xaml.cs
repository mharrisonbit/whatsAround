using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhatsAround.Views
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }
    }
}
