using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CPMobile.Models;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        readonly ICPFeeds cpFeed;

        public ObservableCollection<MyProfile> Profile { get; set; }

        public MyProfile myProfile;
     
        public ProfileViewModel ()
        {
            cpFeed = DependencyService.Get<ICPFeeds>();
            Title = "CodeProject";
            Icon = "icon.png";
            Profile = new ObservableCollection<MyProfile>();
        }

        string username = string.Empty;
        public const string UsernamePropertyName = "DisplayName";
        public string DisplayName
        {
            get { return username; }
            set { SetProperty(ref username, value, UsernamePropertyName); }
        }

        public void CallInit ()
        {

        }

        string avatar = string.Empty;
        public const string AvatarPropertyName = "Avatar";
        public string Avatar
        {
            get { return avatar; }
            set { SetProperty(ref avatar, value, AvatarPropertyName); }
        }

       

        private async Task ExecuteInit ()
        {
            await cpFeed.Init();
        }

        private Command getCPFeedCommand;
        public Command GetCPFeedCommand
        {
            get
            {
                return getCPFeedCommand ??
                    (getCPFeedCommand = new Command(async () => await ExecuteGetCPFeedCommand(), () => { return !IsBusy; }));
            }
        }



        private async Task ExecuteGetCPFeedCommand ()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            GetCPFeedCommand.ChangeCanExecute();

            try
            {
                 myProfile = await cpFeed.GetMyProfile();
                 this.Avatar = myProfile.avatar;
                 this.DisplayName = myProfile.displayName;
                 Profile.Add(myProfile);
                //    avatar.Add(profiles.avatar);
                IsBusy = false;
            }
            catch (Exception ex)
            {

            }
        }


    }
}
