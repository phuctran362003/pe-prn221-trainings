using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace EuroDb2023_TranGiaPhuc.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AccountService _accountService;

        public LoginModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid login attempt.";
                return Page();
            }

            var account = _accountService.Login(Email, Password);

            if (account == null)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            switch (account.RoleId)
            {
                case 1: // Admin
                    return RedirectToPage("/Index");

                case 2: // Staff
                    return RedirectToPage("/Staff/Home");

                case 3: // Manager
                    return RedirectToPage("/Manager/Overview");

                default:
                    ErrorMessage = "Unauthorized role.";
                    return Page();
            }
        }

    }
}
