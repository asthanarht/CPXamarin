using CPMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPMobile.Service;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class FavoriteListViewModel:BaseViewModel
    {
        private Command getFavoriteListCommand;
        public ObservableCollection<Item> FavList { get; set; }

        public FavoriteListViewModel()
        {
            FavList = new ObservableCollection<Item>();
        }
        public Command GetFavoriteListCommand
        {
            get
            {
                return getFavoriteListCommand ??
                    (getFavoriteListCommand = new Command(async () => await ExecuteGetFavCommand(), () => { return !IsBusy; }));
            }
        }



        private async Task ExecuteGetFavCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            GetFavoriteListCommand.ChangeCanExecute();

            try
            {
                var favList = await FavoriteDataService.GetFavListHistory();
                if(favList!=null)
                {
                    foreach (var item in favList)
                    {
                        FavList.Add(item);
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
