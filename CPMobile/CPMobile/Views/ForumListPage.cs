using Xamarin.Forms;
using CPMobile.Helper;

namespace CPMobile.Views
{
    public class ForumListPage : ContentView
    {
        public ForumListPage()
        {
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
                ItemsSource = ForumListData.GetData(),
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
                     var selectedObject = e.SelectedItem as CPMobile.Models.ForumType;

                 var forumPage = new ForumDetailListPage(selectedObject.title,selectedObject.ForumId);
                 Navigation.PushAsync(forumPage);
                };
        }
    }
}
