using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HocGiDo_CORE.Pages
{
    public class dangkyModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegisterVM resgister { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["RegisterResult"] = "Vui lòng điền đầy đủ thông tin!";
                return Page();
            }

            ResultReturn result = await new ExcuteJsonClass().Register(resgister);
            if (result.message.Equals("duplicate") || result.message.Equals("error") || result == null)
            {
                ViewData["RegisterResult"] = "Có lỗi xảy ra rồi!";
                return Page();
            }
            else
            {
                return RedirectToPage("/dangnhap");
            }
        }
    }
}
