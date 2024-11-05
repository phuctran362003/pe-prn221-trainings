using Repository;
using Repository.Entities;

namespace Service
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(Euro2024DbContext context)
        {
            _accountRepository = new AccountRepository(context);
        }

        public Account Login(string email, string password)
        {
            return _accountRepository.GetByEmailAndPassword(email, password);
        }

    }
}
