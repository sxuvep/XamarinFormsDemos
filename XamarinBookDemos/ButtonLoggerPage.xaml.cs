using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class ButtonLoggerPage : ContentPage
    {
        StackLayout loggerLayout = new StackLayout();
        
        public ButtonLoggerPage()
        {
            InitializeComponent();

            Padding = new Thickness(20, 20, 20, 20);
            //create button
            var button = new Button
            {
                Text = "Log the click me"
            };
            button.Clicked += onButtonClicked;

            this.Content = new StackLayout
            {
                Children =
                {
                    button,
                     new ScrollView
                    {
                        VerticalOptions= LayoutOptions.FillAndExpand,
                        Content=loggerLayout
                    }
                }
            };
        }

        void onButtonClicked(object sender, EventArgs e)
        {
            //add label to loggerLayout
            loggerLayout.Children.Add(
                new Label
                {
                    Text = "Button Clicked at " + DateTime.Now.ToString("T")
                });
        }
    }
}
