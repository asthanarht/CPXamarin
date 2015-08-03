using CPMobile.Service;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile
{
    public class CPListCell : ViewCell
    {
        public CPListCell()
        {

            var titleLabel = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 18,
                TextColor = Color.Black
            };
            titleLabel.FontSize = Device.OnPlatform(
                                                        Device.GetNamedSize(NamedSize.Small, titleLabel),
                                                        18,
                                                        Device.GetNamedSize(NamedSize.Small, titleLabel)
                                                    );
            titleLabel.SetBinding(Label.TextProperty, "title");

            var discriptionLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                TextColor = Color.FromHex("#666")
            };
            discriptionLabel.SetBinding(Label.TextProperty, "summary");


            var starLabel = new Label()
            {
                FontSize = 12,
                TextColor = Color.Gray
            };
            starLabel.SetBinding(Label.TextProperty, "rating");

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
                Children = { discriptionLabel }
            };

            var vetDetailsLayout = new StackLayout
            {
                Padding = new Thickness(10, 0, 0, 0),
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { titleLabel, statusLayout, ratingStack }
            };


            //------ Creating Contact Action 1 Start --------//
            var moreAction = new MenuItem { Text = "Favorite"};
            moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            moreAction.Clicked += async (sender, e) => {
                await Task.Run(() => {
                    var mi = ((MenuItem)sender) ;

                    var favListItems = mi.CommandParameter as CPMobile.Models.Item;
                    FavoriteDataService.SaveListItems(favListItems);
                    //Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter as CPMobile.Models.Item);
                });
            };
            ContextActions.Add(moreAction);
            //var tapImage = new Image()
            //{
            //    Source = "tap.png",
            //    HorizontalOptions = LayoutOptions.End,
            //    HeightRequest = 12,
            //};

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { vetDetailsLayout }
            };

            this.View = cellLayout;
        }
    }
}
