using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class AccountRepository : DataAccessObject<SystemAccount>
    {
        public AccountRepository(OilPaintingArt2024DbContext context) : base(context) { }

        public async Task<SystemAccount> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.SystemAccounts.FirstOrDefaultAsync(a => a.AccountEmail == email && a.AccountPassword == password);
        }



    }
}
