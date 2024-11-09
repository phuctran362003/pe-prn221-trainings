using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class AccountRespository : DataAccessObject<Account>
    {
        public AccountRespository(Equipments2024DbContext context) : base(context) { }

        public async Task<Account> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }

    }
}
