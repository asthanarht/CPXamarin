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
            BindingContext= favViewModel = new FavoriteListViewModel(this);
           // favViewModel.GetFavoriteListCommand.Execute(null);
            var searchBar = new SearchBar
            {
                Placeholder = "Search Favorite ",
                BackgroundColor = Color.White,
                CancelButtonColor = App.BrandColor,
            };

          
            var favlist = new ListView
            {
                HasUnevenRows = false,
                ItemTemplate = new DataTemplate(typeof(CPFavList)),
                ItemsSource = favViewModel.FavList,
                BackgroundColor = Color.White,
                RowHeight = 80,
            };

           searchBar.TextChanged += (sender, e) => FilterLocations(favlist,searchBar.Text);
            searchBar.SearchButtonPressed += (sender, e) =>
            {
                
                FilterLocations(favlist,searchBar.Text);
                
            };
            //favlist.SetBinding(ListView.ItemsSourceProperty, "favlist");
            //vetlist.SetBinding<ArticlePageViewModel>();
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { searchBar, favlist }
            };

            favlist.ItemSelected += (sender, e) =>
            {
                var selectedObject = e.SelectedItem as CPMobile.Models.Item;

                var favPage = new WebViewPage(selectedObject.title, selectedObject.websiteLink.HttpUrlFix());
                Navigation.PushAsync(favPage);
                
               
            };

            
            
            //MessagingCenter.Subscribe(this, "DeleteThis", async (string id) =>
            //{
            //    if (String.IsNullOrEmpty(id)) return;
            //    favViewModel.GetFavoriteListCommand.Execute(null); 
            //});
           // favlist.SetBinding(MenuItem.CommandProperty, favViewModel.DeleteItemCommand);

        }

        public void FilterLocations(ListView lv, string filter)
        {
            lv.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter))
            {
                lv.ItemsSource = favViewModel.FavList;
            }
            else
            {
                lv.ItemsSource = favViewModel.FavList
                        .Where(x => x.title.ToLower()
                            .Contains(filter.ToLower()));
            }
            lv.EndRefresh();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (favViewModel.FavList.Count > 0 || favViewModel.IsBusy)
                return;

            favViewModel.GetFavoriteListCommand.Execute(null); 
        }
    }
    
}
