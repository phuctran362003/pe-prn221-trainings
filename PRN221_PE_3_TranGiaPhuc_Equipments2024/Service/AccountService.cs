using Repository;
using Repository.Entities;

namespace Service
{
    public class AccountService
    {
        private readonly AccountRespository _accountRepository;

        public AccountService(Equipments2024DbContext context)
        {
            _accountRepository = new AccountRespository(context);
        }

        public async Task<Account> LoginAsync(string email, string password)
        {
            return await _accountRepository.GetByEmailAndPasswordAsync(email, password);
        }

    }
}
