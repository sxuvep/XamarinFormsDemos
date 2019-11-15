using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class FramedTextPage : ContentPage
    {
        public FramedTextPage()
        {
            InitializeComponent();

            Padding = new Thickness(20);

            Content = new Frame
            {
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.Center,
                BorderColor=Color.Black,
                BackgroundColor=Color.Yellow,
                Content = new Label
                {
                    Text = "I have been framed",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,

                }
            };
        }
    }
}
