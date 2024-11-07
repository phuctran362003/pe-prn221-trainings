using Repository.Entities;

namespace Repository
{
    public class AccountRespository : DataAccessObject<SystemAccount>
    {
        public AccountRespository(OilPaintingArt2024DbContext context) : base(context) { }

        public SystemAccount GetByEmailAndPassword(string email, string password)
        {
            return _context.SystemAccounts.FirstOrDefault(a => a.AccountEmail == email && a.AccountPassword == password);
        }

    }
}
