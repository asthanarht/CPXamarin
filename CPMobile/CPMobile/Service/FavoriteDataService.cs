using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using System.Reactive.Linq;
using CPMobile.Models;

namespace CPMobile.Service
{
    public class FavoriteDataService
    {
        private static List<Item> favListItems;

        public static async void SaveListItems(Item favItem)
        {

            favListItems = await GetFavListHistory();
            if (favListItems != null)
            {
                favListItems.Add(favItem);
            }
            else
            {
                favListItems = new List<Item>();
                favListItems.Add(favItem);
            }
            await BlobCache.LocalMachine.InsertObject<List<Item>>("Favorite", favListItems, DateTimeOffset.Now.AddDays(30));
        }

        public static  async Task<List<Item>> GetFavListHistory()
        {
            try {
                return await BlobCache.LocalMachine.GetObject<List<Item>>("Favorite");
            }
            catch(Exception ex)
            {
                return null;
            }
        }

       
    }
}
