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
    public class suacauhoiConModel : PageModel
    {
        public ListQuestion listQuestion { get; set; }
        public Question question { get; set; }
        public async Task<IActionResult> OnGet(string bh)
        {
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(bh);
            return Page();
        }
    }
}
