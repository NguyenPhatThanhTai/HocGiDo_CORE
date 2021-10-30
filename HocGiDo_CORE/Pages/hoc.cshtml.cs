using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HocGiDo_CORE.Pages
{
    public class hocModel : PageModel
    {
        public Lesson lesson { get; set; }
        public ListLesson listLesson { get; set; }
        public ListQuestion listQuestion { get; set; }
        public string courseID;
        public bool checkSavedLesson = false;
        public async Task<IActionResult> OnGet(string kh, string bh)
        {
            var logined = HttpContext.Session.GetString("Logined");
            if (bh == null)
            {
                return RedirectToPage("/baihoc" + "/" + kh); // truyền parameter qua
            }
            else if(kh == null)
            {
                return RedirectToPage("/index");
            }
            else if(logined == null)
            {
                return RedirectToPage("/dangnhap");
            }
            else
            {
                listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
                lesson = listLesson.BaiHoc.FirstOrDefault(p => p.MaBaiHoc.Equals(bh));

                listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(bh);

                courseID = kh;

                try
                {
                    UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                    ResultReturn resultReturn = await new ExcuteJsonClass().checkSaveLesson(bh, userInf.user.MaND);
                    if (resultReturn.message.Equals("success"))
                    {
                        checkSavedLesson = true;
                    }
                    return Page();
                }
                catch(Exception e)
                {
                    e.Message.ToString();
                    return RedirectToPage("/dangnhap");
                }
            }
        }

        public async Task<JsonResult> OnGetSaveLesson(string MaBH)
        {
            var logined = HttpContext.Session.GetString("Logined");
            if (logined != null)
            {
                UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                ResultReturn resultReturn = await new ExcuteJsonClass().saveLesson(MaBH, userInf.user.MaND);
                return new JsonResult(new
                {
                    status = resultReturn.message,
                    code = "200"
                });
            }
            else
            {
                return new JsonResult(new
                {
                    status = false,
                    code = "500"
                });
            }
        }
    }
}
