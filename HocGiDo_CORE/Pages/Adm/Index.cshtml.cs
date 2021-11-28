using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HocGiDo_CORE.Pages.Adm
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var logined = HttpContext.Session.GetString("AdminLogined");
            if(logined != null)
            {
                UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                if(userInf.user.Quyen == true)
                {
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
