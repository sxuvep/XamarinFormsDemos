using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class VerticalOptionsDemo : ContentPage
    {
        public VerticalOptionsDemo()
        {
            InitializeComponent();

            Color[] colors = { Color.Blue, Color.Yellow };
            int flipFlopper = 0;

            //create labels by ordering them by layout alignment property
            var labels = from field in typeof(LayoutOptions).GetRuntimeFields()
                         where field.IsPublic && field.IsStatic
                         orderby ((LayoutOptions)field.GetValue(null)).Alignment
                         select new Label
                         {
                             Text = "Vertical Options " + field.Name,
                             VerticalOptions = (LayoutOptions)field.GetValue(null),
                             HorizontalTextAlignment = TextAlignment.Center,
                             FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                             TextColor = colors[flipFlopper],
                             BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
                         };

            var stackLayout = new StackLayout
            {
                HorizontalOptions=LayoutOptions.Center
            };

            foreach (var label in labels)
            {
                stackLayout.Children.Add(label);
            }

            this.Content = stackLayout;
        }
    }
}
