using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class WhatSize : ContentPage
    {
        Label label;
        public WhatSize()
        {
            InitializeComponent();

            label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = label;

            SizeChanged += OnPageSizeChanged;
    
        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            label.Text = string.Format("{0} \u00D7 {1}", Width, Height);
        }
    }
}
