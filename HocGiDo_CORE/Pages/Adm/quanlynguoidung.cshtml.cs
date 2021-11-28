using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HocGiDo_CORE.Pages.Adm
{
    public class quanlynguoidungModel : PageModel
    {
        public ListUser listUser { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var logined = HttpContext.Session.GetString("AdminLogined");
            if (logined != null)
            {
                UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                if (userInf.user.Quyen == true)
                {
                    listUser = await new ExcuteJsonClass().getListUser();
                    return Page();
                }
                else
                {
                    return RedirectToPage("/Adm/LoginAdmin");
                }
            }
            else
            {
                return RedirectToPage("/Adm/LoginAdmin");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDeleteUser(string MaTK, string MaND)
        {
            if(MaTK != null && MaND != null)
            {
                ResultReturn result = await new ExcuteJsonClass().deleteUser(MaTK, MaND);
                if (result.message.Equals("success"))
                {
                    TempData["AdminResult"] = "Xóa người dùng thành công";
                    return new JsonResult("Success");
                }
                else
                {
                    TempData["AdminResult"] = "Xóa người dùng thất bại";
                    return new JsonResult("Failed");
                }
            }
            else
            {
                TempData["AdminResult"] = "Đã có lỗi xảy ra";
                return new JsonResult("Failed");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostUpToAdmin(string MaTK)
        {
            if(MaTK != null)
            {
                ResultReturn result = await new ExcuteJsonClass().upToAdmin(MaTK);
                if (result.message.Equals("success"))
                {
                    TempData["AdminResult"] = "Nâng/hạ Admin thành công";
                    return new JsonResult("Success");
                }
                else
                {
                    TempData["AdminResult"] = "Nâng/hạ Admin thất bại";
                    return new JsonResult("Failed");
                }
            }
            else
            {
                TempData["AdminResult"] = "Đã có lỗi xảy ra";
                return new JsonResult("Failed");
            }
        }
    }
}
