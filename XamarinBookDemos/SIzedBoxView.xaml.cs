using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class SIzedBoxView : ContentPage
    {
        public SIzedBoxView()
        {
            InitializeComponent();
            Content = new BoxView
            {
                Color = Color.Accent,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.Center,
                WidthRequest=200,
                HeightRequest=100
            };
        }
    }
}
