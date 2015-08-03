using CPMobile.Models;
using CPMobile.ViewModels;
using Xamarin.Forms;
using CPMobile.Helper;
namespace CPMobile.Views
{
    public class AuthorArticlePage : ContentPage
    {
        AuthorDataViewModel authorDataViewModel;
        public AuthorArticlePage (string title,AuthorDataType authorDataType)
        {
            Title = title;
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this,true);
            NavigationPage.SetBackButtonTitle(this,"Profile");
            authorDataViewModel = new AuthorDataViewModel(authorDataType);
            authorDataViewModel.GetAuthorDataCommand.Execute(null);
            var activityIndicator = new ActivityIndicator
            {
                Color = Color.Gray,
            };
            activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            var vetlist = new ListView
            {
                HasUnevenRows = false,
                ItemTemplate = new DataTemplate(typeof(CPListCell)),
                ItemsSource = authorDataViewModel.AutorItems,
                BackgroundColor = Color.White,
                RowHeight = 120,
            };

            //vetlist.SetBinding<ArticlePageViewModel>();
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { vetlist }
            };

            vetlist.ItemSelected += (sender, e) =>
            {
                var selectedObject = e.SelectedItem as CPMobile.Models.Item;

                var WebViewPage = new WebViewPage(title, selectedObject.websiteLink.HttpUrlFix());
                Navigation.PushAsync(WebViewPage);
            };
        }
    }
}
