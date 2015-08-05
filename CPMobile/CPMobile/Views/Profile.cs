using System;
using CPMobile.Models;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using CPMobile.Helper;
using CPMobile.ViewModels;

namespace CPMobile.Views
{

    public class Profile : ContentPage
    {
       
        public Profile(MyProfile myProfile = null)
        {
            
            Title = "Profile";
            NavigationPage.SetHasNavigationBar(this, true);
            BackgroundColor = Color.White;

            var backgroundImage = new Image()
            {
                BackgroundColor = Color.FromHex("#F57C00"),
                Aspect = Aspect.AspectFill,
                //IsOpaque = false,
                //Opacity = 0.8,
            };

            var shader = new BoxView()
            {
                Color = Color.FromHex("#F57C00").MultiplyAlpha(.5)
            };

            var face = new CircleImage
            {
                BorderColor = Color.White,
                BorderThickness = 2,
                HeightRequest = 100,
                WidthRequest = 100,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source =
                    new UriImageSource { Uri = new Uri(myProfile.avatar), CacheValidity = TimeSpan.FromDays(15) },
            };

            var dome = new Image()
            {
                Aspect = Aspect.AspectFill,
                Source = new FileImageSource() { File = "dome.png" }
            };

            var twitterimage = new Image()
            {
                Source = new FileImageSource() { File = "twitter.png" }
            };

            var tapGestureTwitterRecognizer = new TapGestureRecognizer();
            tapGestureTwitterRecognizer.Tapped +=
                (sender, e) =>
                {
                    var profile = new WebViewPage("Twitter", myProfile.twitterName.TwitterUrl());
                    Navigation.PushAsync(profile);
                };
            twitterimage.GestureRecognizers.Add(tapGestureTwitterRecognizer);

            var linkedinimage = new Image()
            {
                Source = new FileImageSource() { File = "linkedin.png" }
            };

            var tapGestureLinkedInRecognizer = new TapGestureRecognizer();
            tapGestureLinkedInRecognizer.Tapped +=
                (sender, e) =>
                {
                    var profile = new WebViewPage("LinkedIn", myProfile.linkedInProfile);
                    Navigation.PushAsync(profile);
                };
            linkedinimage.GestureRecognizers.Add(tapGestureLinkedInRecognizer);


            var details = new DetailsView(myProfile);
            var slideshow = new ShowProfileDetailsView();

          

            RelativeLayout relativeLayout = new RelativeLayout()
            {
                HeightRequest = 100,
            };

            relativeLayout.Children.Add(
                backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .35;
                })
            );

            relativeLayout.Children.Add(
                shader,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .35;
                })
            );

            relativeLayout.Children.Add(
                dome,
                Constraint.Constant(-10),
                Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Height * .35) - 50;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width + 10;
                }),
                Constraint.Constant(75)
            );

            relativeLayout.Children.Add(
                twitterimage,
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .05;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Height * .35);
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .15;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .15;
                })
            );

            relativeLayout.Children.Add(
                linkedinimage,
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .95 - (parent.Width * .15);
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Height * .35);
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .15;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .15;
                })
            );

            relativeLayout.Children.Add(
                face,
                Constraint.RelativeToParent((parent) =>
                {
                    return ((parent.Width / 2) - (face.Width / 2));
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .1;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .5;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .5;
                })
            );

            relativeLayout.Children.Add(
                details,
                Constraint.Constant(0),
                Constraint.RelativeToView(dome, (parent, view) =>
                {
                    return view.Y + view.Height + 10;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.Constant(200)
            );

            relativeLayout.Children.Add(
                    slideshow,
                    Constraint.Constant(0),
                    Constraint.RelativeToView(details, (parent, view) =>
                    {
                        return view.Y + view.Height;
                    }),
                    Constraint.RelativeToParent((parent) =>
                    {
                        return parent.Width;
                    }),
                    Constraint.RelativeToView(details, (parent, view) =>
                    {
                        var detailsbottomY = view.Y + view.Height;
                        return parent.Height - detailsbottomY;
                    })
                );

            face.SizeChanged += (sender, e) =>
            {
                relativeLayout.ForceLayout();
            };

            this.Content = relativeLayout;

        }
    }
}
