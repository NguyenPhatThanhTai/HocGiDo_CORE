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

namespace HocGiDo_CORE.Pages.Adm
{
    public class quanlybaihocModel : PageModel
    {
        public Course listCourse { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var logined = HttpContext.Session.GetString("AdminLogined");
            if (logined != null)
            {
                UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                if (userInf.user.Quyen == true)
                {
                    listCourse = await new ExcuteJsonClass().getCourse();
                    return Page();
                }
                else
                {
                    return RedirectToPage("/Adm/LoginAdmin");
                }
            }
            else
            {
                return RedirectToPage("/Adm/LoginAdmin");
            }
        }
    }
}
