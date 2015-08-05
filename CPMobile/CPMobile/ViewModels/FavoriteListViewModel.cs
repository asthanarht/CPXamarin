using CPMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPMobile.Service;
using Xamarin.Forms;
using System.Windows.Input;

namespace CPMobile.ViewModels
{
    public class FavoriteListViewModel:BaseViewModel
    {
        private Command getFavoriteListCommand;
        public ObservableCollection<Item> FavList { get; set; }

        public FavoriteListViewModel(Page page):base(page)
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

        private ICommand _deleteItemCommand;
         public const string DeleteCommandPropertyName = "DeleteCommand";
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                {
                    _deleteItemCommand = new Command(async () => await ExecuteGetFavCommand(), () => { return !IsBusy; });
                }

                return _deleteItemCommand;
            }
            //set
            //{
            //    SetProperty(ref _deleteItemCommand, value, DeleteCommandPropertyName);
            //}
           
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
