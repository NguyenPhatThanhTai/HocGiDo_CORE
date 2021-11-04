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

namespace HocGiDo_CORE.Pages
{
    public class suakhoahocConModel : PageModel
    {
        private IHostingEnvironment Environment;

        public suakhoahocConModel(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        public Course listCourse { get; set; }
        public ListCourse course { get; set; }
        public async Task<IActionResult> OnGet(string kh)
        {
            listCourse = await new ExcuteJsonClass().getCourse();
            course = listCourse.KhoaHoc.First(p => p.MaKH.Equals(kh));

            return Page();
        }

        [BindProperty]
        public UpdateCourse updateCourse { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (updateCourse.mauSac == null || updateCourse.moTaKH == null || updateCourse.tenKH == null || updateCourse.CourseImage == null || updateCourse.maKH == null)
            {
                ViewData["AdminResult"] = "Vui lòng điền đầy đủ thông tin cập nhật!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return RedirectToPage("/Adm/quanlykhoahoc");
            }
            try
            {
                var uniqueFileName = GetUniqueFileName(updateCourse.CourseImage.FileName);
                var uploads = Path.Combine(Environment.WebRootPath, "CourseImage");
                var filePath = Path.Combine(uploads, updateCourse.tenKH + ".jpg");

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                updateCourse.CourseImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listCourse = await new ExcuteJsonClass().getCourse();
                return Page();
            }

            ResultReturn result = await new ExcuteJsonClass().updateCourse(updateCourse);

            if (result.message.Equals("success"))
            {
                ViewData["AdminResult"] = "Đã cập nhật thành công!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return RedirectToPage("/Adm/quanlykhoahoc");
            }
            else
            {
                ViewData["AdminResult"] = "Đã có lỗi xảy ra!";
                listCourse = await new ExcuteJsonClass().getCourse();
                return RedirectToPage("/Adm/quanlykhoahoc");
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
