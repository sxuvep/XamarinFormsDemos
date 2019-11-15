using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class NamedFontSIzes : ContentPage
    {
        public NamedFontSIzes()
        {
            InitializeComponent();
            BackgroundColor = Color.White;

            StackLayout stackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            //do namedsize values

            NamedSize[] namedSizes =
            {
                NamedSize.Default,NamedSize.Micro,NamedSize.Small,NamedSize.Medium,NamedSize.Large
            };

            foreach (var namedSize in namedSizes)
            {
                double fontSize = Device.GetNamedSize(namedSize, typeof(Label));
                stackLayout.Children.Add(new Label
                {
                    Text = string.Format("Named Size {0} = {1:F2}", namedSize, fontSize),
                    FontSize = fontSize,
                    TextColor = Color.Black
                });
            }

            //Resultion in device independent units per inch
            var resolution = 160;

            //draw a horizontal separator
            stackLayout.Children.Add(
                new BoxView
                {
                    Color = Color.Accent,
                    HeightRequest = resolution / 80
                });

            //do some point sizes
            int[] ptSizes = { 4, 6, 8, 10, 12 };

            foreach (var ptSize in ptSizes)
            {
                double fontSize = resolution * ptSize / 72;

                stackLayout.Children.Add(new Label
                {
                    Text = string.Format("Point-Size= {0} ({1:F2})", ptSize, fontSize),
                    FontSize = fontSize,
                    TextColor = Color.Black
                });
            }


            Content = stackLayout;
        }
    }
}
