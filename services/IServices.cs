namespace CustoMate.services
{
    public interface IServices <T>
    {
        void CreateAsync(T Item);
        Task<T> UpdateItemAsync(T item);

        Task<T> DeleteItemAsync(T item);

        Task<IEnumerable<T>> GetAllItemsAsync();

        Task<T> GetItemByIdAsync(int id);

        Task<bool> SaveChangesAsync();


    }
}
