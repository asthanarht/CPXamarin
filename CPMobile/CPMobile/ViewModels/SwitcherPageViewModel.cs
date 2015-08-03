using System.Collections.Generic;
using System.Linq;
using CPMobile.ViewModels;
using Xamarin.Forms;

namespace CustomLayouts.ViewModels
{
    public class SwitcherPageViewModel : BaseViewModel
    {
        public SwitcherPageViewModel()
        {
            Pages = new List<HomeViewModel>() {
				new HomeViewModel { Title = "Article", Background = Color.White, ImageSource = "icon.png" },
				new HomeViewModel { Title = "Forum", Background = Color.Red, ImageSource = "icon.png" },
				new HomeViewModel { Title = "Question", Background = Color.Blue, ImageSource = "icon.png" },
			};

            CurrentPage = Pages.First();
        }

        IEnumerable<HomeViewModel> _pages;
        public IEnumerable<HomeViewModel> Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                SetObservableProperty(ref _pages, value);
                CurrentPage = Pages.FirstOrDefault();
            }
        }

        HomeViewModel _currentPage;
        public HomeViewModel CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                SetObservableProperty(ref _currentPage, value);
            }
        }
    }

    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel() { }

        public string Title { get; set; }
        public Color Background { get; set; }
        public string ImageSource { get; set; }
    }
}

