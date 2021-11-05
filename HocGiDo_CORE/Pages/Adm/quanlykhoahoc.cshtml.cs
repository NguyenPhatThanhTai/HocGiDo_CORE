using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            listCourse = await new ExcuteJsonClass().getCourse();
            return Page();
        }

        [BindProperty]
        public AddCourse addCourse { get; set; }
        public async Task<IActionResult> OnPostAddCourse()
        {
            if (addCourse.mauSac == null || addCourse.moTaKH == null || addCourse.tenKH == null || addCourse.CourseImage == null)
            {
                ViewData["AdminResult"] = "Vui lòng điền đầy đủ thông tin!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return Page();
            }
            try
            {
                var uniqueFileName = GetUniqueFileName(addCourse.CourseImage.FileName);
                var uploads = Path.Combine(Environment.WebRootPath, "CourseImage");
                var filePath = Path.Combine(uploads, addCourse.tenKH + ".jpg");
                addCourse.CourseImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            catch(Exception e)
            {
                e.Message.ToString();
                listCourse = await new ExcuteJsonClass().getCourse();
                return Page(); ;
            }

            ResultReturn result = await new ExcuteJsonClass().addCourse(addCourse);

            if (result.message.Equals("success"))
            {
                ViewData["AdminResult"] = "Đã thêm thành công!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return Page(); ;
            }
            else
            {
                ViewData["AdminResult"] = "Đã có lỗi xảy ra!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return Page(); ;
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
