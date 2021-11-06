using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HocGiDo_CORE.Pages.Adm
{
    public class suabaihocConModel : PageModel
    {
        public ListLesson listLesson { get; set; }
        public Lesson lesson { get; set; }
        public async Task<IActionResult> OnGet(string kh, string bh)
        {
            listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
            lesson = listLesson.BaiHoc.First(p => p.MaBaiHoc.Equals(bh));
            return Page();
        }
    }
}
