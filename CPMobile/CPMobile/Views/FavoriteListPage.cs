using CPMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using CPMobile.Helper;

using Xamarin.Forms;

namespace CPMobile.Views
{
    public class FavoriteListPage : ContentPage
    {
        FavoriteListViewModel favViewModel;
        public FavoriteListPage()
        {
            Title = "Favorite";
            NavigationPage.SetHasNavigationBar(this, true);
            BindingContext=favViewModel = new FavoriteListViewModel();
            favViewModel.GetFavoriteListCommand.Execute(null);
            var searchBar = new SearchBar
            {
                Placeholder = "Search Forum ",
                BackgroundColor = Color.White,
                CancelButtonColor = App.BrandColor,
            };
            var vetlist = new ListView
            {
                HasUnevenRows = false,
                ItemTemplate = new DataTemplate(typeof(CustomListStyle)),
                ItemsSource = favViewModel.FavList,
                BackgroundColor = Color.White,
                RowHeight = 50,
            };

            //vetlist.SetBinding<ArticlePageViewModel>();
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { searchBar, vetlist }
            };

            vetlist.ItemSelected += (sender, e) =>
            {
                var selectedObject = e.SelectedItem as CPMobile.Models.Item;

                var favPage = new WebViewPage(selectedObject.title, selectedObject.websiteLink.HttpUrlFix());
                Navigation.PushAsync(favPage);
            };
        }
    }
    
}
