using System;
using System.Collections.Generic;
using System.Globalization;
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

            if (IsDateBeforeOrToday(resgister.Birth.ToString("MM/dd/yyyy")))
            {
                ResultReturn result = await new ExcuteJsonClass().Register(resgister);
                if (result.message.Equals("duplicate"))
                {
                    ViewData["RegisterResult"] = "Tài khoản đã tồn tại trên hệ thống!";
                    return Page();
                }
                if (result.message.Equals("error") || result == null)
                {
                    ViewData["RegisterResult"] = "Có lỗi xảy ra rồi!";
                    return Page();
                }
                else
                {
                    return RedirectToPage("/dangnhap");
                }
            }
            else
            {
                ViewData["RegisterResult"] = "Ngày sinh không hợp lệ!";
                return Page();
            }
        }
        public static bool IsDateBeforeOrToday(string date)
        {
            var parameterDate = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var todaysDate = DateTime.Today;

            if (parameterDate < todaysDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
