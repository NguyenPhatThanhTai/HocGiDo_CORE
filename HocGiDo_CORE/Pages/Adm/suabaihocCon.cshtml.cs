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
    public class suabaihocConModel : PageModel
    {
        public ListLesson listLesson { get; set; }
        public Lesson lesson { get; set; }
        public async Task<IActionResult> OnGet(string kh, string bh)
        {
            TempData["MaKH"] = kh;
            listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
            lesson = listLesson.BaiHoc.First(p => p.MaBaiHoc.Equals(bh));
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPostUpdateLesson([FromBody] Lesson lesson)
        {
            if(lesson.MaBaiHoc != null)
            {
                TempData["MaKH"] = lesson.MaKH;
                ResultReturn result = await new ExcuteJsonClass().updateLesson(lesson);
                if (result.message.Equals("success"))
                {
                    TempData["AdminResult"] = "Sửa bài học thành công!";
                    return new JsonResult("Success");
                }
                else
                {
                    TempData["AdminResult"] = "Sửa bài học thất bại!";
                    return new JsonResult("Failed");
                }
            }
            else
            {
                TempData["AdminResult"] = "Có lỗi xảy ra!";
                return new JsonResult("Failed");
            }
        }
    }
}
