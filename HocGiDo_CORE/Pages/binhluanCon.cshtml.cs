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
    public class binhluanConModel : PageModel
    {
        public ListComment listComment { get; set; }
        public async Task<IActionResult> OnGet(string bh)
        {
            listComment = await new ExcuteJsonClass().getListComment(bh);

            return Page();
        }
    }
}
