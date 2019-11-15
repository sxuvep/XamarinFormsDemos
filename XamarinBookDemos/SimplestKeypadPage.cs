using System;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public class SimplestKeypadPage : ContentPage
    {
        Label displayLabel;
        Button backspaceButton;

        public SimplestKeypadPage()
        {
            Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 20 : 5, 5, 5);

            //create main stack
            StackLayout mainStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            //first row is a display label
             displayLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };

            mainStack.Children.Add(displayLabel);

            //second row is backspace button

             backspaceButton = new Button
            {
                Text = "\u21E6",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                IsEnabled = false
            };

            backspaceButton.Clicked += onBackspaceButtonClick;

            mainStack.Children.Add(backspaceButton);

            //add 10 digits to the keypad

            StackLayout rowStack = null;

            for (int i = 1; i <= 10; i++)
            {
                if((i-1) %3==0)
                {
                    rowStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                    };

                    mainStack.Children.Add(rowStack);
                }

                Button digitButton = new Button
                {
                    Text = (i % 10).ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    StyleId = (i % 10).ToString()
                };
                digitButton.Clicked += onDigitButtonClick;

                if(i==10)
                {
                    digitButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                }

                rowStack.Children.Add(digitButton);

            }

            this.Content = mainStack;
        }

        private void onDigitButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            displayLabel.Text += (string)button.StyleId;
            backspaceButton.IsEnabled = true;
        }

        private void onBackspaceButtonClick(object sender, EventArgs e)
        {
            var displayText = displayLabel.Text;
            displayLabel.Text = displayText.Substring(0, displayText.Length - 1);
            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
        }
    }
}

