using Repository.Entities;

namespace Repository
{
    public class AccountRepository : DataAccessObject<Account>
    {
        public AccountRepository(Euro2024DbContext context) : base(context) { }


        public Account GetByEmailAndPassword(string email, string password)
        {
            return _context.Accounts.FirstOrDefault(a => a.Email == email && a.Password == password);

        }


    }
}
