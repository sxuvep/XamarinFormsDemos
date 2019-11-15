using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class XamlClock : ContentPage
    {
        public XamlClock()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), onTimerClick);
        }

        private bool onTimerClick()
        {
            DateTime dt = DateTime.Now;

            timeLabel.Text = dt.ToString("T");
            dateLabel.Text = dt.ToString("D");
            return true;
        }
    }
}
