using CustoMate.entity;
using CustoMate.exst;
using Microsoft.EntityFrameworkCore;

namespace CustoMate.services
{
    public class UserServices : IServices<User>
    {
        private readonly CustoMateDb _custoMateDb;

        public UserServices(CustoMateDb custoMateDb)
        {
            _custoMateDb = custoMateDb;
        }
        public void CreateAsync(User Item)
        {
            var role = _custoMateDb.Roles.FirstOrDefault(c=>c.RoleName == Item.Role.RoleName);

            Item.Role = role;
           _custoMateDb.Users.Add(Item);
        }

        public Task<User> DeleteItemAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllItemsAsync()
        {
           return await _custoMateDb.Users.ToListAsync();
        }

        public async Task<User> GetItemByIdAsync(int id)
        {
            var user = await _custoMateDb.Users.Where(c => c.Id == id).Include(c => c.Role).FirstOrDefaultAsync() ;

            return user;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _custoMateDb.SaveChangesAsync() > 0;
        }

        public Task<User> UpdateItemAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
