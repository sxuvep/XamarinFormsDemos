using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class ButtonLamdas : ContentPage
    {
        public ButtonLamdas()
        {
            InitializeComponent();

            int number = 1;

            Label label = new Label
            {
                Text = number.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button timesButton = new Button
            {
                Text = "Double",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            timesButton.Clicked += (sender, args) =>
            {
                number = number * 2;
                label.Text = number.ToString();

            };

            Button divideButton = new Button
            {
                Text = "Half",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            divideButton.Clicked += (sender, args) =>
            {
                number = number / 2;
                label.Text = number.ToString();
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    label,
                    new StackLayout
                    {
                        Orientation= StackOrientation.Horizontal,
                        VerticalOptions=LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            timesButton,
                            divideButton
                        }
                    }

                }
            };
        }
    }
}
