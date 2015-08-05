using CPMobile.ViewModels;
using Xamarin.Forms;
using CPMobile.Models;

namespace CPMobile.Views
{
    public class ArticleListPage:ContentView
    {
        ArticleViewModel articleViewModel;
        public ArticleListPage()
        {
           articleViewModel = new ArticleViewModel();
           articleViewModel.GetCPFeedCommand.Execute(null);
            var activityIndicator = new ActivityIndicator
            {
                Color = Color.White,
            };
            activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            var genralArticlelist = new ListView
            {
                HasUnevenRows = false,
                ItemTemplate = new DataTemplate(typeof(CPListCell)),
                ItemsSource = articleViewModel.Articles,
                BackgroundColor = Color.White,
                RowHeight=100,
            };
           
            //vetlist.SetBinding<ArticlePageViewModel>();
             Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { genralArticlelist  }
            };

             genralArticlelist.ItemSelected += (sender, e) =>
             {
                 var selectedObject = e.SelectedItem as CPMobile.Models.Item;

                 var WebViewPage = new WebViewPage("General Articles",string.Format("http:{0}",selectedObject.websiteLink));
                 Navigation.PushAsync(WebViewPage);
                // Navigation.PushAsync( );
             };
           
        }

      
    }
}
