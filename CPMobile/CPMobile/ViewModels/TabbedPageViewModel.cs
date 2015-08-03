using System.Collections.Generic;
using System.Linq;

namespace CPMobile.ViewModels
{
    public class TabbedPageViewModel : BaseViewModel
    {
        public TabbedPageViewModel()
        {
            Title = "CodeProject";
            Icon = "icon.png";
            Pages = new List<ICarouselViewModel>
            {
                new ArticlePageViewModel(),
			    new ForumViewModel()
            };
        }

        private IEnumerable<ICarouselViewModel> _pages;

        public IEnumerable<ICarouselViewModel> Pages
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

        private ICarouselViewModel _currentPage;

        public ICarouselViewModel CurrentPage
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
}
