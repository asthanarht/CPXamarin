using System;
using CPMobile.Views;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class ArticlePageViewModel :ICarouselViewModel
    {
        public ContentView View
        {
            get { return new ArticleListPage(); }
        }


        public string TabText
        {
            get { return "Article"; }
        }

        public string TabIcon
        {
            get
            {
                return "article.png";
            }
        }
    }
}
