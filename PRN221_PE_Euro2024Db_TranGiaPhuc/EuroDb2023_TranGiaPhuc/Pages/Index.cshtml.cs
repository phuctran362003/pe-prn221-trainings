using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace EuroDb2023_TranGiaPhuc.Pages
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



        public IActionResult OnPost()
        {
            try
            {
                var account = _accountService.Login(email, password);
                if (account != null && (account.RoleId == 2 || account.RoleId == 3))
                {
                    TempData["Message"] = "Login Success";
                    Console.WriteLine("Login Success");

                    //set session
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetInt32("RoleId", account.RoleId ?? default(int));

                    return RedirectToPage("/OilPaintingArtPage/Index");
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
