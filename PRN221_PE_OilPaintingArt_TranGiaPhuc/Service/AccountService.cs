using Repository;
using Repository.Entities;

namespace Service
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(OilPaintingArt2024DbContext context)
        {
            _accountRepository = new AccountRepository(context);
        }

        public async Task<SystemAccount> LoginAsync(string email, string password)
        {
            return await _accountRepository.GetByEmailAndPasswordAsync(email, password);
        }

    }
}


