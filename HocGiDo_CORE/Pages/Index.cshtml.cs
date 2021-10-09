using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HocGiDo_CORE.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //

        private static readonly HttpClient client = new HttpClient();
        public Course courses { get; set; }

        public async Task<IActionResult> OnGet()
        {
            courses = await getCourse();
            return Page();
        }
        public async Task<Course> getCourse()
        {
            var responseString = await client.GetStringAsync("http://diepquangduc-001-site1.etempurl.com/api/khoahoc");
            var resp = JsonConvert.DeserializeObject<Course>(responseString);
            return resp;
        }
    }
}
