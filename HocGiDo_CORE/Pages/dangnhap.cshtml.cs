using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HocGiDo_CORE.Pages
{
    public class dangnhapModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoginVM login { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Có lỗi rồi");
                return Page();
            }

            ResultReturn result = await new ExcuteJsonClass().Login(login);
            if (result.message.Equals("error"))
            {
                ViewData["LoginResult"] = "Sai mật khẩu hoặc tài khoản, vui lòng kiểm tra lại";
            }
            else
            {
                ViewData["LoginResult"] = "Đăng nhập thành công, mã tài khoản là : " + result.message;
            }

            return Page();
        }
    }
}
