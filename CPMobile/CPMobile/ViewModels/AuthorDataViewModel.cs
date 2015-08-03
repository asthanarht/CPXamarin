using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CPMobile.Models;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class AuthorDataViewModel: BaseViewModel
    {
        readonly ICPFeeds cpFeed;

        public ObservableCollection<Item> AutorItems { get; set; }

        private AuthorDataType authorDataType;
        public AuthorDataViewModel(AuthorDataType dataType)
        {
            this.authorDataType = dataType;
             cpFeed = DependencyService.Get<ICPFeeds>();
             AutorItems = new ObservableCollection<Item>();
        }

        public void CallInit()
        {
            ExecuteInit();
        }

        private async Task ExecuteInit()
        {
            await cpFeed.Init();
        }

        private Command getAuthorDataCommand;
        public Command GetAuthorDataCommand
        {
            get
            {
                return getAuthorDataCommand ??
                    (getAuthorDataCommand = new Command(async () => await ExecuteGetAuthorDataCommand(), () => { return !IsBusy; }));
            }
        }



        private async Task ExecuteGetAuthorDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            GetAuthorDataCommand.ChangeCanExecute();

            try
            {
                CPFeed authorDataFeed = null;
                switch(authorDataType)
                {
                    case AuthorDataType.Article:
                        {
                            authorDataFeed = await cpFeed.MyArticles(1);
                            break;
                        }
                    case AuthorDataType.Message:
                        {
                            authorDataFeed = await cpFeed.MyMessage(1);
                            break;
                        }
                    case AuthorDataType.Comments:
                        {
                            authorDataFeed = await cpFeed.MyComments(1);
                            break;
                        }
                    case AuthorDataType.Tips:
                        {
                            authorDataFeed = await cpFeed.MyTips(1);
                            break;
                        }
                    case AuthorDataType.TechBlog:
                        {
                            authorDataFeed = await cpFeed.MyBlogs(1);
                            break;
                        }
                }

                foreach (var article in authorDataFeed.items)
                {
                    AutorItems.Add(article);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
