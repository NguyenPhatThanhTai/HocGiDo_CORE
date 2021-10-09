using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;

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
        public Course courses { get; set; }

        public async Task<IActionResult> OnGet()
        {
            courses = await new ExcuteJsonClass().getCourse();
            return Page();
        }
    }
}
