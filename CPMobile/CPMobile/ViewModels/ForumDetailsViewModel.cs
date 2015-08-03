using CPMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class ForumDetailsViewModel: BaseViewModel
    {
        readonly ICPFeeds cpFeed;
        private int forumId;
        public ObservableCollection<Item> ForumList { get; set; }
        public ForumDetailsViewModel(int id)
        {
            cpFeed = DependencyService.Get<ICPFeeds>();
            ForumList = new ObservableCollection<Item>();
            this.forumId = id;
        }

        private Command getForumListCommand;
        public Command GetForumListCommand
        {
            get
            {
                return getForumListCommand ??
                    (getForumListCommand = new Command(async () => await ExecuteGetCPFeedCommand(), () => { return !IsBusy; }));
            }
        }



        private async Task ExecuteGetCPFeedCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            GetForumListCommand.ChangeCanExecute();

            try
            {
                var forums = await cpFeed.GetForumAsync(forumId);
                foreach (var forum in forums.items)
                {
                    ForumList.Add(forum);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
