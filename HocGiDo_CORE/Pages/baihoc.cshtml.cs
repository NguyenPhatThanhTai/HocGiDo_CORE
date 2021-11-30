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
        public ListCourse course { get; set; } 

        public string courseID;
        public bool checkRegisterCourse = false;
        public bool checkLogined = false;
        public async Task<IActionResult> OnGet(string MaKH)
        {
            if(MaKH == null)
            {
                return RedirectToPage("/Index"); // truyền parameter qua
            }
            else
            {
                Course courses = await new ExcuteJsonClass().getCourse();
                course = courses.KhoaHoc.FirstOrDefault(p => p.MaKH.Equals(MaKH));
                await check(MaKH);
                return Page();
            }
        }

        public async Task<IActionResult> OnGetRegisterCourse(string MaKH)
        {
            var logined = HttpContext.Session.GetString("Logined");
            if(logined != null)
            {
                UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                ResultReturn result = await new ExcuteJsonClass().registerCourse(MaKH, userInf.user.MaND);

                await check(MaKH);

                if (result.message.Equals("success"))
                {
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/dangnhap");
            }
        }

        public async Task<bool> check(string MaKH)
        {
            courseID = MaKH;
            listLesson = await new ExcuteJsonClass().getLessonOfCourse(MaKH);

            var logined = HttpContext.Session.GetString("Logined");

            if (logined != null)
            {
                try
                {
                    UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                    checkLogined = true;

                    ResultReturn result = await new ExcuteJsonClass().checkRegisterCourse(MaKH, userInf.user.MaND);
                    if (result.message.Equals("success"))
                    {
                        checkRegisterCourse = true;
                    }
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            return true;
        }
    }
}
