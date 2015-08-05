using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Akavache;
using Xamarin.Forms;
using CPMobile.Models;
using System.Collections.ObjectModel;

namespace CPMobile.ViewModels
{
    public class ShowProfileDetailsViewModel:BaseViewModel
    {
        private Command getProfileDetailsCommand;
        public ObservableCollection<AuthorProfileDataCounts> FavList { get; set; }

        public ShowProfileDetailsViewModel()
        {
            FavList = new ObservableCollection<AuthorProfileDataCounts>();
        }
        public Command GetProfileDetailsCommand
        {
            get
            {
                return getProfileDetailsCommand ??
                    (getProfileDetailsCommand = new Command(async () => await ExecuteGetProfileDetailsCommand(), () => { return !IsBusy; }));
            }
        }
        string message = string.Empty;
        public const string AuthorMessagesPropertyName = "AuthorMessages";
        public string AuthorMessages
        {
            get { return message; }
            set { SetProperty(ref message, value, AuthorMessagesPropertyName); }
        }
        string comments = string.Empty;
        public const string AuthorCommentsPropertyName = "AuthorComments";
        public string AuthorComments
        {
            get { return comments; }
            set { SetProperty(ref comments, value, AuthorCommentsPropertyName); }
        }
        string tips = string.Empty;
        public const string AuthorTipsPropertyName = "AuthorTips";
        public string AuthorTips
        {
            get { return tips; }
            set { SetProperty(ref tips, value, AuthorTipsPropertyName); }
        }
        string blogs = string.Empty;
        public const string AuthorBlogsPropertyName = "AuthorBlogs";
        public string AuthorBlogs
        {
            get { return blogs; }
            set { SetProperty(ref blogs, value, AuthorBlogsPropertyName); }
        }
        string article = string.Empty;
        public const string AuthorArticlesPropertyName = "AuthorArticles";
        public string AuthorArticles
        {
            get { return article; }
            set { SetProperty(ref article, value, AuthorArticlesPropertyName); }
        }
        private List<string> GetAllKeys()
        {
            var list = new List<string>();
            list.Add("AuthorMessages");
            list.Add("AuthorComments");
            list.Add("AuthorTips");
            list.Add("AuthorBlogs");
            list.Add("AuthorArticles");
            return list;
        }

        private async Task ExecuteGetProfileDetailsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            GetProfileDetailsCommand.ChangeCanExecute();

            try
            {
                var listCount = await BlobCache.LocalMachine.GetObjects<string>(GetAllKeys());
               
                foreach (var item in listCount)
                {
                    if (item.Key.Contains("AuthorMessages"))
                    {
                        this.AuthorMessages = item.Value;
                    }
                    if (item.Key.Contains("AuthorComments"))
                    {
                        this.AuthorComments = item.Value;
                    }
                    if (item.Key.Contains("AuthorTips"))
                    {
                        this.AuthorTips = item.Value;
                    }
                    if (item.Key.Contains("AuthorBlogs"))
                    {
                        this.AuthorBlogs = item.Value;
                    }
                    if (item.Key.Contains("AuthorArticles"))
                    {
                        this.AuthorArticles = item.Value;
                    }
                    
                        
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
