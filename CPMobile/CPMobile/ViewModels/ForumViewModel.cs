using System;
using CPMobile.Views;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class ForumViewModel : ICarouselViewModel
    {
        public ContentView View
        {
            get { return new ForumListPage(); }
        }


        public string TabText
        {
            get { return "Forum"; }
        }

        public string TabIcon
        {
            get
            {
                return "forum.png";
            }
        }
    }
}
