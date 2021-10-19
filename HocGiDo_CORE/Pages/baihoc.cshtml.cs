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
    public class baihocModel : PageModel
    {
        public ListLesson listLesson { get; set; }
        public string courseID;
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
                return Page();
            }
        }
    }
}
