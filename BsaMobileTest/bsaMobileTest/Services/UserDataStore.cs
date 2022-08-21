using bsaMobileTest.Models;
using SQLite;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace bsaMobileTest.Services
{
    public class UserDataStore : IStore<User>
    {
        public UserDataStore(string databasePath) => (_database = new SQLiteAsyncConnection(databasePath))?.CreateTableAsync<User>().Wait();

        readonly SQLiteAsyncConnection _database;
        public Task<int> AddItemAsync(User user) => _database.InsertAsync(user);

        public Task DeleteItemAsync(int id) => _database.Table<User>().DeleteAsync(x => x.Id == id);

        public Task<User> GetItemAsync(int id) => _database.Table<User>().FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<User>> GetItemsAsync() => _database.Table<User>().ToListAsync();

        public Task UpdateItemAsync(User item) => _database.UpdateAsync(item);
    }
}