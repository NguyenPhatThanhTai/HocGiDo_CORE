using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HocGiDo_CORE.Pages
{
    public class hocModel : PageModel
    {
        public Lesson lesson { get; set; }
        public ListLesson listLesson { get; set; }
        public string courseID;
        public async Task<IActionResult> OnGet(string kh, string bh)
        {
            if (kh == null)
            {
                return RedirectToPage("/baihoc" + "/" + kh); // truyền parameter qua
            }
            else
            {
                listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
                lesson = listLesson.BaiHoc.FirstOrDefault(p => p.MaBaiHoc.Equals(bh));
                courseID = kh;
                return Page();
            }
        }
    }
}
