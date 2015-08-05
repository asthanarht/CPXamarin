using Xamarin.Forms;

namespace CPMobile.Views
{
    public class RootPage :MasterDetailPage
    {
        MenuPage menuPage;

        public RootPage()
        {
            menuPage = new MenuPage(this);
            Master = menuPage;
            Detail = new NavigationPage(new MainListPage() ){  BarBackgroundColor = App.BrandColor, BarTextColor= Color.White };
        }

        //void NavigateTo(MenuItem menu)
        //{
        //    if (menu == null)
        //        return;

        //    //Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

        //    //Detail = new NavigationPage(displayPage);

        //    //menuPage.Menu.SelectedItem = null;
        //    IsPresented = false;
        //}
    }
}
