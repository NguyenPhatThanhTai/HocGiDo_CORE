using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HocGiDo_CORE.Pages.Adm
{
    public class LoginAdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("AdminLogined");
            return Page();
        }

        [BindProperty]
        public LoginVM loginAdmin { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["LoginResult"] = "Vui lòng điền đầy đủ thông tin!";
                return Page();
            }

            ResultReturn result = await new ExcuteJsonClass().Login(loginAdmin);
            var userInf = await new ExcuteJsonClass().getUser(result.message);
            if (result == null || result.message.Equals("error"))
            {
                ViewData["LoginResult"] = "Tài khoản này không tồn tại!";
                return Page();
            }
            else
            {
                if (userInf.user.Quyen == false)
                {
                    ViewData["LoginResult"] = "Tài khoản này không phải Admin!";
                    return Page();
                }
                else
                {
                    HttpContext.Session.SetString("AdminLogined", JsonConvert.SerializeObject(userInf));
                    return RedirectToPage("/Adm/Index");
                }
            }
        }
    }
}
