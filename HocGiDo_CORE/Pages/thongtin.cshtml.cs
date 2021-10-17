using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                return Page();
            }
        }
    }
}
