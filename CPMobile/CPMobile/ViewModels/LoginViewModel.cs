using System.Threading.Tasks;
using CPMobile.Models;
using CPMobile.Views;
using Xamarin.Forms;
using System;

namespace CPMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly ICPFeeds cpFeeds;


        public LoginViewModel(Page page)
            : base(page)
        {
            this.cpFeeds = DependencyService.Get<ICPFeeds>();
        }

        public const string LoginCommandPropertyName = "LoginCommand";
        Command loginCommand;
        public Command LoginCommand
        {
            get
            {
                return loginCommand ??
                    (loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }

        private async Task ExecuteLoginCommand()
        {
          
            bool isLoginSuccess = false;
            if (IsBusy)
                return;

            IsBusy = true;
            loginCommand.ChangeCanExecute();

            try
            {
                isLoginSuccess = await cpFeeds.GetAccessToken("asthanarht@gmail.com", "#include");
            }
            catch(Exception ex)
            {
                isLoginSuccess = false;
            }

            finally
            {
                IsBusy = false;
                loginCommand.ChangeCanExecute();
            }

            if (isLoginSuccess)
            {
                await page.Navigation.PushModalAsync(new RootPage());
            }
            else
            {
                await page.DisplayAlert("Login Error", "Login Error! please try Again", "Ok");
            }
        }


        string username = string.Empty;
        public const string UsernamePropertyName = "UserName";
        public string UserName
        {
            get { return username; }
            set { SetProperty(ref username, value, UsernamePropertyName); }
        }

        string password = string.Empty;
        public const string PasswordPropertyName = "Password";
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value, PasswordPropertyName); }
        }
    }
}
