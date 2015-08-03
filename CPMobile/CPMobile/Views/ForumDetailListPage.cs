using System;
using CPMobile.Models;
using CPMobile.ViewModels;
using Xamarin.Forms;

namespace CPMobile.Views
{
    public class ForumDetailListPage: ContentPage
    {
        ForumDetailsViewModel forumViewModel;
        public ForumDetailListPage(string name,int forumId)
        {
            Title = name;
            NavigationPage.SetHasNavigationBar(this, true);
            BindingContext=forumViewModel = new ForumDetailsViewModel(forumId);
            forumViewModel.GetForumListCommand.Execute(null);

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
                ItemsSource = forumViewModel.ForumList,
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

                var WebViewPage = new WebViewPage(name,  selectedObject.websiteLink);
                Navigation.PushAsync(WebViewPage);
            };
        }
    }
}
