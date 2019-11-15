using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class TwoButtonsPage : ContentPage
    {
        Button addButton, removeButton;
        StackLayout loggerLayout = new StackLayout();
        public TwoButtonsPage()
        {
            InitializeComponent();

            addButton = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            addButton.Clicked += onButtonClicked;

            removeButton = new Button
            {
                Text = "Remove",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            removeButton.Clicked += onButtonClicked;

            this.Content = new StackLayout
            {
                Children={
                    addButton,
                    removeButton,
                    new ScrollView
                    {
                        VerticalOptions=LayoutOptions.FillAndExpand,
                        Content=loggerLayout
                    }
                }
            };
        }

        private void onButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if(button==addButton)
            {
                loggerLayout.Children.Add(new Label
                {
                    Text = "Button Clicked at " + DateTime.Now.ToString("T")
                });
            }
            else
            {
                loggerLayout.Children.RemoveAt(0);
            }

            removeButton.IsEnabled = loggerLayout.Children.Count > 0;
        }
    }
}
