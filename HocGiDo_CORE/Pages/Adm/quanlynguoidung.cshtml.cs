using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace HocGiDo_CORE.Pages.Adm
{
    public class quanlynguoidungModel : PageModel
    {
        public ListUser listUser { get; set; }
        public async Task<IActionResult> OnGet()
        {
            listUser = await new ExcuteJsonClass().getListUser();
            return Page();
        }
    }
}
