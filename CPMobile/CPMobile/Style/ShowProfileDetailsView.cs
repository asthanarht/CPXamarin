using CPMobile.Models;
using CPMobile.Views;
using Xamarin.Forms;

namespace CPMobile
{
    public class ShowProfileDetailsView : ContentView
    {
        public ShowProfileDetailsView(MyProfile myProfile = null)
        {
            HeightRequest = 200;

            var article = new Label()
            {
                Text = "Article",
                FontSize = 20,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var articleCount = new Label()
            {
                Text = "4",
                FontSize = 14,
                FontFamily = Device.OnPlatform("HelveticaNeue", "sans-serif", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var stackArticle = new StackLayout()
            {
                Padding = new Thickness(20, 10),
                BackgroundColor = App.BrandColor,
                Children = {
					article,
					articleCount,
				}
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped +=
                (sender, e) =>
                {
                    var authorArticles = new AuthorArticlePage("Article",AuthorDataType.Article);
                    Navigation.PushAsync(authorArticles);
                };
            stackArticle.GestureRecognizers.Add(tapGestureRecognizer);

            var techBlog = new Label()
            {
                Text = "Technical Blog",
                FontSize = 18,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var techBlogCount = new Label()
            {
                Text = "40",
                FontSize = 14,
                FontFamily = Device.OnPlatform("HelveticaNeue", "sans-serif", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var stackBlog = new StackLayout()
            {
                Padding = new Thickness(20, 10),
                BackgroundColor = App.BrandColor,
                Children = {
					techBlog,
					techBlogCount,
				}
            };

            var tapGestureBlogMessageRecognizer = new TapGestureRecognizer();
            tapGestureBlogMessageRecognizer.Tapped +=
                (sender, e) =>
                {
                    var authorArticles = new AuthorArticlePage("Technical Blog",AuthorDataType.TechBlog);
                    Navigation.PushAsync(authorArticles);
                };

            stackBlog.GestureRecognizers.Add(tapGestureBlogMessageRecognizer);
            
            var message = new Label()
            {
                Text = "Message",
                FontSize = 20,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var messageCount = new Label()
            {
                Text = "184",
                FontSize = 14,
                FontFamily = Device.OnPlatform("HelveticaNeue", "sans-serif", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var stackMessage = new StackLayout()
            {
                Padding = new Thickness(20, 10),
                BackgroundColor = App.BrandColor,
                Children = {
					message,
					messageCount,
				}
            };

            var tapGestureMessageRecognizer = new TapGestureRecognizer();
            tapGestureMessageRecognizer.Tapped +=
                (sender, e) =>
                {
                    var authorArticles = new AuthorArticlePage("Message",AuthorDataType.Message);
                    Navigation.PushAsync(authorArticles);
                };
            stackMessage.GestureRecognizers.Add(tapGestureMessageRecognizer);

            var tip = new Label()
            {
                Text = "Tip&Trick",
                FontSize = 20,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var tipCount = new Label()
            {
                Text = "24",
                FontSize = 14,
                FontFamily = Device.OnPlatform("HelveticaNeue", "sans-serif", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var stackTip = new StackLayout()
            {
                Padding = new Thickness(20, 10),
                BackgroundColor = App.BrandColor,
                Children = {
					tip,
					tipCount,
				}
            };

            var tapGestureTipsRecognizer = new TapGestureRecognizer();
            tapGestureTipsRecognizer.Tapped +=
                (sender, e) =>
                {
                    var authorArticles = new AuthorArticlePage("Tips & Tricks",AuthorDataType.Tips);
                    Navigation.PushAsync(authorArticles);
                };

            stackTip.GestureRecognizers.Add(tapGestureTipsRecognizer);
            var comments = new Label()
            {
                Text = "Comment",
                FontSize = 20,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var commentsCount = new Label()
            {
                Text = "84",
                FontSize = 14,
                FontFamily = Device.OnPlatform("HelveticaNeue", "sans-serif", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.White
            };

            var stackComments = new StackLayout()
            {
                HeightRequest = 200,
                BackgroundColor = App.BrandColor,
                Padding = new Thickness(20, 10),
                Children = {
					comments,
					commentsCount,
				}
            };

            var tapGestureCommentsMessageRecognizer = new TapGestureRecognizer();
            tapGestureCommentsMessageRecognizer.Tapped +=
                (sender, e) =>
                {
                    var authorArticles = new AuthorArticlePage("Comments",AuthorDataType.Comments);
                    Navigation.PushAsync(authorArticles);
                };

            stackComments.GestureRecognizers.Add(tapGestureCommentsMessageRecognizer);

            //overall

            var stack = new StackLayout()
            {
                Padding = new Thickness(0, 0, 0, 10),
                Orientation = StackOrientation.Horizontal,

                Spacing = 10,
                Children = {
					stackArticle,
					stackMessage,
					stackTip,
					stackBlog,
					stackComments,
				}
            };

            Content = new ScrollView()
            {
                Content = stack,
                Orientation = ScrollOrientation.Horizontal
            };
        }
    }
}
