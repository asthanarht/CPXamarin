using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile
{
    public class CustomListStyle:ViewCell
    {
        public CustomListStyle()
        {
            //var vetProfileImage = new CircleImage
            //{
            //    BorderColor = Color.FromHex("#F2995D"),
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
            nameLabel.SetBinding(Label.TextProperty, "title");

            
            // Vet rating label and star image
            //var starLabel = new Label()
            //{
            //    FontSize = 12,
            //    TextColor = Color.Gray
            //};
            //starLabel.SetBinding(Label.TextProperty, "Stars");

            //var starImage = new Image()
            //{
            //    Source = "star.png",
            //    HeightRequest = 12,
            //    WidthRequest = 12
            //};

            //var ratingStack = new StackLayout()
            //{
            //    Spacing = 3,
            //    Orientation = StackOrientation.Horizontal,
            //    Children = { starImage, starLabel }
            //};

           

            var vetDetailsLayout = new StackLayout
            {
                Padding = new Thickness(10, 0, 0, 0),
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { nameLabel }
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
                Children = { vetDetailsLayout, tapImage }
            };

            this.View = cellLayout;
        }
    }
}
