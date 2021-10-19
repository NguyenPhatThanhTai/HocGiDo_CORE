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
    public class codeModel : PageModel
    {
        public Lesson lesson { get; set; }
        public async Task<IActionResult> OnGet(string kh,string bh)
        {
            if(bh == null)
            {
                lesson = null;
                return Page();
            }
            else
            {
                ListLesson listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
                lesson = listLesson.BaiHoc.FirstOrDefault(p => p.MaBaiHoc.Equals(bh));
                return Page();
            }
        }
    }
}
