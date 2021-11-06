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
    public class quanlybaihocConModel : PageModel
    {
        public ListLesson listLesson { get; set; }
        public ListQuestion listQuestion { get; set; }
        public async Task<IActionResult> OnGet(string kh)
        {
            listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(kh);
            return Page();
        }
    }
}
