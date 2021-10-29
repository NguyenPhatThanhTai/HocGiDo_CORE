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
    public class baihocModel : PageModel
    {
        public ListLesson listLesson { get; set; }
        public string courseID;
        public bool checkRegisterCourse = false;
        public bool checkLogined = false;
        public async Task<IActionResult> OnGet(string kh)
        {
            if(kh == null)
            {
                return RedirectToPage("/Index", new { id = 3 }); // truyền parameter qua
            }
            else
            {
                courseID = kh;
                listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);

                var logined = HttpContext.Session.GetString("Logined");
                if(logined != null)
                {
                    try
                    {
                        UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                        checkLogined = true;

                        if (new ExcuteJsonClass().checkRegisterCourse(kh, userInf.user.MaND).Equals("success"))
                        {
                            checkRegisterCourse = true;
                        }
                    }
                    catch(Exception e)
                    {
                        e.Message.ToString();
                    }
                }

                return Page();
            }
        }
    }
}
