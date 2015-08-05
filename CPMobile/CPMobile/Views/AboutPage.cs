using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile.Views
{
    public class AboutPage: ContentPage
    {
        public AboutPage()
        {
            Padding = new Thickness(20);
            NavigationPage.SetHasNavigationBar(this, true);
            BackgroundColor = Color.White;
            var License = new Label
            {
                Text = "The Code Project Open License (CPOL) 1.02",
                BackgroundColor = App.BrandColor,
                Font = Font.SystemFontOfSize(30),
                WidthRequest = 150,
                HeightRequest =150
            };

            var Author = new Label
            {
                Text = "Author - Rohit Asthana",
                BackgroundColor = App.BrandColor,
                Font = Font.SystemFontOfSize(15),
                WidthRequest = 50,
                HeightRequest = 50
            };

            Content = new StackLayout
            {
                Spacing = 10,
                Children = { Author,License }
            };
        }
    }
}
