using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CPMobile.Models;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class AuthorArticleViewModel: BaseViewModel
    {
        readonly ICPFeeds cpFeed;

        public ObservableCollection<Item> Articles { get; set; }
        public AuthorArticleViewModel ()
        {
            cpFeed = DependencyService.Get<ICPFeeds>();
            Title = "CodeProject";
            Icon = "icon.png";
            Articles = new ObservableCollection<Item>();
        }

        public void CallInit()
        {
            ExecuteInit();
        }

        private async Task ExecuteInit()
        {
            await cpFeed.Init();
        }

        private Command getAuthorArticleCommand;
        public Command GetAuthorArticleCommand
        {
            get
            {
                return getAuthorArticleCommand ??
                    (getAuthorArticleCommand = new Command(async () => await ExecuteGetCPFeedCommand(), () => { return !IsBusy; }));
            }
        }



        private async Task ExecuteGetCPFeedCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            GetAuthorArticleCommand.ChangeCanExecute();

            try
            {
                var articles = await cpFeed.MyArticles(1);
                foreach(var article in articles.items)
                {
                    Articles.Add(article);
                }
                IsBusy = false;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
