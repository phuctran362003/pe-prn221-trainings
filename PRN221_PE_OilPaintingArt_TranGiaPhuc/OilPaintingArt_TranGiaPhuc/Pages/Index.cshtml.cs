using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace OilPaintingArt_TranGiaPhuc.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        private readonly AccountService _accountService;
        public IndexModel(AccountService accountService)
        {
            _accountService = accountService;
        }



        public async Task<IActionResult> OnPost()
        {
            try
            {
                var account = await _accountService.LoginAsync(email, password);
                if (account != null && (account.Role == 1 || account.Role == 2))
                {
                    TempData["Message"] = "Login Success";
                    Console.WriteLine("Login Success");

                    // Set session
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetInt32("RoleId", account.Role.GetValueOrDefault());

                    return RedirectToPage("/OilPainting/Index");
                }
                else
                {
                    TempData["Message"] = "You do not have permission to do this function";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }

    }
}
