using System;
using System.Reflection;
using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class ReflectedColorsPage : ContentPage
    {
        public ReflectedColorsPage()
        {
            InitializeComponent();

            var stackLayout = new StackLayout
            {
                BackgroundColor = Color.Blue,
                Orientation=StackOrientation.Vertical
            };

            //loop through the color structure fields
            foreach (var info in typeof(Color).GetRuntimeFields())
            {
                //dont add obsolete colors
                if (info.GetCustomAttribute<ObsoleteAttribute>() != null)
                    continue;

                if (info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(null), info.Name));
                }
            }

            Content = new ScrollView
            {
                Content = stackLayout,
                BackgroundColor=Color.Red,
                Orientation=ScrollOrientation.Horizontal
            };
        }

        private View CreateColorLabel(Color color, string name)
        {
            var backgroundColor = Color.Default;
            if(color !=Color.Default)
            {
                // Standard luminance calculation.
                double luminance = 0.30 * color.R + 0.59 * color.G +
                0.11 * color.B;

                backgroundColor = luminance > 0.5 ? Color.Black : Color.White;

            }

            var label=new Label
            {
                Text = name,
                TextColor = color,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                BackgroundColor=backgroundColor,
            };

            return label;
        }
    }
}
