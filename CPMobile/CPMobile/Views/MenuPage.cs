using Xamarin.Forms;

namespace CPMobile.Views
{
    public class MenuTableView :TableView
    {

    }
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; set; }
        RootPage rootPage;
        TableView tableView;

        public MenuPage(RootPage rootPage)
        {
            Icon = "menu.png";
            Title = "menu"; // The Title property must be set.

            this.rootPage = rootPage;

            var logoutButton = new Button { Text = "Logout" };
            logoutButton.Clicked += (sender, e) =>
            {
                App.Current.LogOut();
            };
            var layout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#FF9800"),
            };
            var section = new TableSection()
            {
                new MenuCell {Text = "Home",Host= this,ImageSrc="home_black.png"},
                new MenuCell {Text = "Favorites",Host= this,ImageSrc="star_black.png"},
                new MenuCell {Text = "About",Host= this,ImageSrc="about_black.png"},
            };
            
            var root = new TableRoot() { section };

            tableView = new MenuTableView()
            {
                Root = root,
                Intent = TableIntent.Data,
                //BackgroundColor = Color.FromHex("2C3E50"),
                BackgroundColor = Color.White,

            };

            var settingView = new SettingsUserView();

            //settingView.tapped += (object sender, TapViewEventHandler e) =>
            //{

            //    Navigation.PushAsync(new Profile());
            //    // var home = new NavigationPage(new Profile());
            //    // rootPage.Detail = home;
            //};

            layout.Children.Add(settingView);
            //layout.Children.Add(new BoxView()
            //{
            //    HeightRequest = 1,
            //    BackgroundColor = AppStyle.DarkLabelColor,
            //});
            layout.Children.Add(tableView);
            layout.Children.Add(logoutButton);

            Content = layout;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped +=
                (sender, e) =>
                {
                    NavigationPage profile = new NavigationPage(new Profile(settingView.profileViewModel.myProfile)) { BarBackgroundColor = App.BrandColor };
                    rootPage.Detail = profile;
                    rootPage.IsPresented = false;
                };
            settingView.GestureRecognizers.Add(tapGestureRecognizer);
 
        }

        NavigationPage home, favorite, favorites;
        public void Selected(string item)
        {

            switch (item)
            {
                case "Home":
                    if (home == null)
                        home = new NavigationPage(new MainListPage()) { BarBackgroundColor = App.BrandColor, BarTextColor = Color.White };
                    rootPage.Detail = home;
                    break;
                case "Favorites":
                    favorites = new NavigationPage(new FavoriteListPage()) { BarBackgroundColor = App.BrandColor, BarTextColor = Color.White };
                    rootPage.Detail = favorites;
                    break;
                case "Room Plan":
                    rootPage.Detail = new NavigationPage(new RootPage());// { BarBackgroundColor = App.NavTint };
                    break;
                case "Contact":
                    rootPage.Detail = new NavigationPage(new RootPage());// { BarBackgroundColor = App.NavTint };
                    break;
                case "About":
                    rootPage.Detail = new NavigationPage(new RootPage());// { BarBackgroundColor = App.NavTint };
                    break;
            };
            rootPage.IsPresented = false;  // close the slide-out
        }

    }

    
}
