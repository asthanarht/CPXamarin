using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CPMobile  
{
    public class MainListCell : ViewCell
    {
        public MainListCell()
        {
            //var vetProfileImage = new CircleImage
            //{
            //    BorderColor = Color.Green,
            //    BorderThickness = 2,
            //    HeightRequest = 50,
            //    WidthRequest = 50,
            //    Aspect = Aspect.AspectFill,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //};
            //vetProfileImage.SetBinding(Image.SourceProperty, "ImageSource");

            var nameLabel = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 18,
                TextColor = Color.Black
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var distanceLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                TextColor = Color.FromHex("#666")
            };
            distanceLabel.SetBinding(Label.TextProperty, new Binding("Distance", stringFormat: "{0} Miles Away"));

            // Online image and label
           

            // Vet rating label and star image
            var starLabel = new Label()
            {
                FontSize = 12,
                TextColor = Color.Gray
            };
            starLabel.SetBinding(Label.TextProperty, "Stars");

            var starImage = new Image()
            {
                Source = "star.png",
                HeightRequest = 12,
                WidthRequest = 12
            };

            var ratingStack = new StackLayout()
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                Children = { starImage, starLabel }
            };

            var statusLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { distanceLabel }
            };

            var vetDetailsLayout = new StackLayout
            {
                Padding = new Thickness(10, 0, 0, 0),
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { nameLabel, statusLayout, ratingStack }
            };

            var tapImage = new Image()
            {
                Source = "tap.png",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 12,
            };

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {  vetDetailsLayout, tapImage }
            };

            this.View = cellLayout;

        }

        public class Vet
        {
            public UriImageSource ImageSource { get; set; }

            public string Name { get; set; }

            public string Distance { get; set; }

            public bool IsOnLine { get; set; }

            public string OnLineStatus { get; set; }

            public string AwayTime { get; set; }

            public string Stars { get; set; }

            public bool ShouldShowAsOnline { get { return IsOnLine == true; } }

            public bool ShouldShowAsOffline { get { return IsOnLine == false; } }
        }

        public static class VetData
        {
            public static List<Vet> GetData()
            {
                return new List<Vet> {
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					Name = "Bryan Garret",
					Distance = "0.2",
					IsOnLine = true, 
					Stars = "3.5"
				},
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1rYGvGU") },
					Name = "James Simpson",
					Distance = "0.5",
					IsOnLine = true, 
					Stars = "5"
				},
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1EhFsao") },
					Name = "Kathryn Newer",
					Distance = "1.1",
					IsOnLine = true, 
					Stars = "4.5"
				},
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1oIYpso") },
					Name = "Amanda Stevens",
					Distance = "1.3",
					IsOnLine = false, 
					Stars = "4"
				},
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/10CbVZE") },
					Name = "Wayne Andrews",
					Distance = "3.0",
					IsOnLine = true, 
					Stars = "4.5"
				},
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1vCRbKh ") },
					Name = "David Cameron",
					Distance = "4",
					IsOnLine = true, 
					Stars = "1.5"
				},
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1rPp1vm") },
					Name = "Jeff Alexander",
					Distance = "4.2",
					IsOnLine = true, 
					Stars = "3.5"
				},
				new Vet () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1sXguu1") },
					Name = "Boby Fisher",
					Distance = "5.1",
					IsOnLine = true, 
					Stars = "4.5"
				}
			};
            }
        }
    }
}
