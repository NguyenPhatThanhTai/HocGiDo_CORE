using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HocGiDo_CORE.Pages
{
    public class thongtinModel : PageModel
    {
        public UserInf userInf { get; set; }
        public ListCourseRegisted listCourseRegisted { get; set; }
        public ListSavedLesson listSavedLesson { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var logined = HttpContext.Session.GetString("Logined");
            if (logined == null)
            {
                return RedirectToPage("/dangnhap");
            }
            else
            {
                userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                DateTime birth = DateTime.Parse(userInf.user.NgaySinh);
                userInf.user.NgaySinh = birth.ToString("yyyy-MM-dd");
                listCourseRegisted = await new ExcuteJsonClass().getListCourseRegisted(userInf.user.MaND);

                listSavedLesson = await new ExcuteJsonClass().getListSavedLesson(userInf.user.MaND);

                return Page();
            }
        }
    }
}
