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
    public class quanlybaihocModel : PageModel
    {
        public Course listCourse { get; set; }
        public async Task<IActionResult> OnGet()
        {
            listCourse = await new ExcuteJsonClass().getCourse();
            return Page();
        }
    }
}
