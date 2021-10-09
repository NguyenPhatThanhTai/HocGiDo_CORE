using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HocGiDo_CORE.Pages
{
    public class listModel : PageModel
    {
        public String testParam { get; set; }
        public IActionResult OnGet([FromQuery(Name = "id")] string id)
        {
            //testParam = id;
            return Page();
            //return RedirectToPage("./test");
        }

        [BindProperty]
        public testModel testMD { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Có lỗi rồi");
                return Page();
            }

            testModel test = testMD;
            ViewData["test"] = test.Name;
            return Page();

            //return RedirectToPage("./Index");
        }
    }
}
