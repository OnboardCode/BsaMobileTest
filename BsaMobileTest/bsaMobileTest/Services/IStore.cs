using System.Collections.Generic;
using System.Threading.Tasks;

namespace bsaMobileTest.Services
{
    public interface IStore<T>
    {
        Task<int> AddItemAsync(T item);
        Task UpdateItemAsync(T item);
        Task DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<List<T>> GetItemsAsync();
    }
}
