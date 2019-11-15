using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace XamarinBookDemos
{
    public partial class ColorBlocks : ContentPage
    {
        public ColorBlocks()
        {
            InitializeComponent();

            var stackLayout = new StackLayout
            {
                BackgroundColor = Color.Blue,
                Padding= new Thickness(5,20,5,5)
            };

            foreach (var fieldInfo in typeof(Color).GetRuntimeFields())
            {
                if(fieldInfo.IsPublic && fieldInfo.IsStatic)
                {
                    stackLayout.Children.Add(CreateColorView((Color)fieldInfo.GetValue(null),fieldInfo.Name));
                }
            }

            //foreach (var property in typeof(Color).GetRuntimeProperties())
            //{
            //    if(property.GetMethod.IsPublic && property.GetMethod.IsStatic)
            //    {
            //        stackLayout.Children.Add(property.)
            //    }
            //}

            Content = new ScrollView
            {
                Content = stackLayout
            };
        }

        private View CreateColorView(Color color, string name)
        {
            return new Frame
            {
                BorderColor = Color.Accent,
                Padding = new Thickness(5),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                    {
                       new BoxView
                       {
                           Color=color
                       },
                       new Label
                       {
                           Text=name,
                           FontSize= Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                           VerticalOptions= LayoutOptions.Center,
                           FontAttributes= FontAttributes.Bold,
                           HorizontalOptions=LayoutOptions.StartAndExpand

                       },
                       new StackLayout
                       {
                           Children=
                           {
                              new Label
                              {
                                  Text = String.Format("{0:X2}-{1:X2}-{2:X2}",(int)(255 * color.R),(int)(255 * color.G),(int)(255 * color.B)),
                                  VerticalOptions=LayoutOptions.CenterAndExpand,
                                  IsVisible=color!=Color.Default
                              },
                              new Label
                              {
                                  Text=string.Format("{0:F2}-{1:F2}-{2:F2}",color.Hue,color.Saturation,color.Luminosity),
                                  VerticalOptions= LayoutOptions.CenterAndExpand,
                                  IsVisible=color!=Color.Default
                              }
                           },
                           HorizontalOptions=LayoutOptions.End
                       }
                    }
                }
            };
        }
    }
}
