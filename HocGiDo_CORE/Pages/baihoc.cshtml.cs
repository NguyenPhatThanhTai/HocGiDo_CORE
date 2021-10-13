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
        public async Task<IActionResult> OnGet([FromQuery(Name = "id")] string id)
        {
            if(id == null)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                listLesson = await new ExcuteJsonClass().getLessonOfCourse(id);
                return Page();
            }
        }
    }
}
