using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using CPMobile.Service;

namespace CPMobile
{
    public class CPFavList: ViewCell
    {

        public CPFavList()
        {

            var nameLabel = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 18,
                TextColor = Color.Black
            };
            nameLabel.SetBinding(Label.TextProperty, "title");
            nameLabel.FontSize = Device.OnPlatform(
                                                        Device.GetNamedSize(NamedSize.Small, nameLabel),
                                                        16,
                                                        Device.GetNamedSize(NamedSize.Small, nameLabel)
                                                    );
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

            //------ Creating Contact Action 1 Start --------//
            var deleteAction = new MenuItem { Text = "Delete" ,IsDestructive=true };
            deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            deleteAction.Clicked += async (sender, e) =>
            {
                await Task.Run(() =>
                {
                    var mi = ((MenuItem)sender);

                    var favListItems = mi.CommandParameter as CPMobile.Models.Item;
                    FavoriteDataService.DeleteFavorite(favListItems);
                    //Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter as CPMobile.Models.Item);
                });
            };
            ContextActions.Add(deleteAction);

            this.View = cellLayout;
        }
    }
}
