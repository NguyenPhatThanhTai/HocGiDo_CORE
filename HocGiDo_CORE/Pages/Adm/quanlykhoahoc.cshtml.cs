using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HocGiDo_CORE.Pages.Adm
{
    public class managerCourseModel : PageModel
    {

        private IHostingEnvironment Environment;

        public managerCourseModel(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        public Course listCourse { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var logined = HttpContext.Session.GetString("AdminLogined");
            if (logined != null)
            {
                UserInf userInf = JsonConvert.DeserializeObject<UserInf>(logined);
                if (userInf.user.Quyen == true)
                {
                    listCourse = await new ExcuteJsonClass().getCourse();
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

        [BindProperty]
        public AddCourse addCourse { get; set; }
        public async Task<IActionResult> OnPostAddCourse()
        {
            if (addCourse.mauSac == null || addCourse.moTaKH == null || addCourse.tenKH == null || addCourse.CourseImage == null)
            {
                TempData["AdminResult"] = "Vui lòng điền đầy đủ thông tin!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return Page();
            }
            try
            {
                ResultReturn result = await new ExcuteJsonClass().addCourse(addCourse);
                if (!result.message.Equals("error"))
                {
                    var uniqueFileName = GetUniqueFileName(addCourse.CourseImage.FileName);
                    var uploads = Path.Combine(Environment.WebRootPath, "CourseImage");
                    var filePath = Path.Combine(uploads, result.message.ToString() + ".jpg");
                    addCourse.CourseImage.CopyTo(new FileStream(filePath, FileMode.Create));

                    TempData["AdminResult"] = "Đã thêm thành công!";
                    listCourse = await new ExcuteJsonClass().getCourse();
                    return Page();
                }
                else
                {
                    TempData["AdminResult"] = "Đã có lỗi xảy ra!";
                    listCourse = await new ExcuteJsonClass().getCourse();
                    return Page();
                }
            }
            catch(Exception e)
            {
                e.Message.ToString();
                listCourse = await new ExcuteJsonClass().getCourse();
                return Page();
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPostDeleteCourse(string MaKH)
        {
            if (MaKH != null)
            {
                ResultReturn isDeleted = await new ExcuteJsonClass().deleteCourse(MaKH);
                if (isDeleted.message.ToString().Equals("success"))
                {
                    var uploads = Path.Combine(Environment.WebRootPath, "CourseImage");
                    var filePath = Path.Combine(uploads, MaKH + ".jpg");

                    if (System.IO.File.Exists(filePath))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(filePath);
                    }

                    TempData["AdminResult"] = "Xóa khóa học thành công!";
                    listCourse = await new ExcuteJsonClass().getCourse();
                    return new JsonResult("Success");
                }
                else
                {
                    TempData["AdminResult"] = "Đã có lỗi xảy ra!";
                    listCourse = await new ExcuteJsonClass().getCourse();
                    return new JsonResult("Error");
                }
            }
            else
            {
                TempData["AdminResult"] = "Không có ID truyền vào!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return new JsonResult("Error");
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
