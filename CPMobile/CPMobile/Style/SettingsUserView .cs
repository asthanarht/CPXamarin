using System;
using CPMobile.ViewModels;
using CPMobile.Views;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace CPMobile
{
    public class SettingsUserView : ContentView
    {
        public ProfileViewModel profileViewModel;
        public SettingsUserView()
        {
            BindingContext = profileViewModel = new ProfileViewModel();

            profileViewModel.GetCPFeedCommand.Execute(null);
            var activityIndicator = new ActivityIndicator
            {
                Color = Color.Black,
            };

            activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            var circleImage = new CircleImage
            {
                BorderColor = Color.White,
                BorderThickness = 2,
                HeightRequest = 80,
                WidthRequest = 80,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source =
                    new UriImageSource { Uri = new Uri("http://bit.ly/1s07h2W"), CacheValidity = TimeSpan.FromDays(30) },
            };

            var label = new Label()
            {
                Text = "User",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Content = new StackLayout()
            {
                Padding = new Thickness(0, 10, 0, 0),
                Spacing = 15,
                Orientation = StackOrientation.Vertical,
                Children = {circleImage,
				label,
				activityIndicator,
				}
            };

            circleImage.SetBinding(CircleImage.SourceProperty, "Avatar");

            label.SetBinding(Label.TextProperty, "DisplayName");

            //var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped +=
            //    (sender, e) =>
            //        Navigation.PushModalAsync(new NavigationPage(new Profile(profileViewModel.myProfile)) { BarBackgroundColor = App.BrandColor });
            //circleImage.GestureRecognizers.Add(tapGestureRecognizer);
            
        }
    }
}
