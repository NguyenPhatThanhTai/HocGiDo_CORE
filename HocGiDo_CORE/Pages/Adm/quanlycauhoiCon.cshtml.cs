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
    public class quanlycauhoiConModel : PageModel
    {
        public ListQuestion listQuestion { get; set; }
        public string lessonId { get; set; }
        public async Task <IActionResult> OnGet(string bh)
        {
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(bh);
            lessonId = bh;
            return Page();
        }
    }
}
