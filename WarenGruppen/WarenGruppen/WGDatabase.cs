using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarenGruppen
{
    public class WGDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public WGDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ItemProperties>().Wait();
        }

        public Task<List<ItemProperties>> GetWGAsync()
        {
            return _database.Table<ItemProperties>().ToListAsync();
        }

        public Task<int> GetListCount()
        {
            return _database.Table<ItemProperties>().CountAsync();
        }
        public Task<ItemProperties> GetItemAsync(int id)
        {
            return _database.Table<ItemProperties>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveWGAsync(ItemProperties itemProp)
        {
            return _database.InsertAsync(itemProp);
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _database.Table<ItemProperties>().Where(x => x.ID == id).FirstOrDefaultAsync();
            if (item != null)
            {
                await _database.DeleteAsync(item);
            }
        }

        public Task<int> DeleteAllItems<T>()
        {
            return _database.DeleteAllAsync<ItemProperties>();
        }

       

    }
}
