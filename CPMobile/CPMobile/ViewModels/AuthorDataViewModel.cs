using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CPMobile.Models;
using Xamarin.Forms;
using Akavache;
using System.Reactive.Linq;

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
                            authorDataFeed = await BlobCache.LocalMachine.GetOrFetchObject<CPFeed>("MyArticle",
                                                                                            async () => await cpFeed.MyArticles(1),
                                                                                            DateTimeOffset.Now.AddDays(3)
                                                                                        );
                            // I dont like this but let it be
                            await BlobCache.LocalMachine.InsertObject<string>("AuthorArticles", authorDataFeed.pagination.totalItems.ToString(), DateTimeOffset.Now.AddDays(3));
                            break;
                        }
                    case AuthorDataType.Message:
                        {
                            authorDataFeed = await BlobCache.LocalMachine.GetOrFetchObject<CPFeed>("MyMessage",
                                                                                           async () => await cpFeed.MyMessage(1),
                                                                                           DateTimeOffset.Now.AddDays(3)
                                                                                       );
                            await BlobCache.LocalMachine.InsertObject<string>("AuthorMessages", authorDataFeed.pagination.totalItems.ToString(), DateTimeOffset.Now.AddDays(3));

                            break;
                        }
                    case AuthorDataType.Comments:
                        {
                            authorDataFeed = await BlobCache.LocalMachine.GetOrFetchObject<CPFeed>("MyComments",
                                                                                           async () => await cpFeed.MyComments(1),
                                                                                           DateTimeOffset.Now.AddDays(3)
                                                                                       );
                            await BlobCache.LocalMachine.InsertObject<string>("AuthorComments", authorDataFeed.pagination.totalItems.ToString(), DateTimeOffset.Now.AddDays(3));

                            break;
                        }
                    case AuthorDataType.Tips:
                        {
                            
                            authorDataFeed = await BlobCache.LocalMachine.GetOrFetchObject<CPFeed>("MyTips",
                                                                                           async () => await cpFeed.MyTips(1),
                                                                                           DateTimeOffset.Now.AddDays(3)
                                                                                       );
                            await BlobCache.LocalMachine.InsertObject<string>("AuthorTips", authorDataFeed.pagination.totalItems.ToString(), DateTimeOffset.Now.AddDays(3));

                            break;
                        }
                    case AuthorDataType.TechBlog:
                        {
                          
                            authorDataFeed = await BlobCache.LocalMachine.GetOrFetchObject<CPFeed>("MyBlogs",
                                                                                           async () => await cpFeed.MyBlogs(1),
                                                                                           DateTimeOffset.Now.AddDays(3)
                                                                                       );
                            await BlobCache.LocalMachine.InsertObject<string>("AuthorBlogs", authorDataFeed.pagination.totalItems.ToString(), DateTimeOffset.Now.AddDays(3));

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
