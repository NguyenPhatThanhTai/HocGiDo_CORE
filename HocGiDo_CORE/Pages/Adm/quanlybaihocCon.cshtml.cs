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
    public class quanlybaihocConModel : PageModel
    {
        public Lesson lesson { get; set; }
        public ListLesson listLesson { get; set; }
        public ListQuestion listQuestion { get; set; }
        public string MaKH { get; set; }
        public async Task<IActionResult> OnGet(string kh)
        {
            MaKH = kh;
            TempData["MaKH"] = kh;
            listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(kh);
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPostAddLesson([FromBody] Lesson lessonAdd)
        {
            MaKH = lessonAdd.MaKH;
            listLesson = await new ExcuteJsonClass().getLessonOfCourse(lessonAdd.MaKH);
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(lessonAdd.MaKH);
            TempData["MaKH"] = lessonAdd.MaKH;

            ResultReturn result = await new ExcuteJsonClass().addLesson(lessonAdd);
            if (result.message.Equals("success"))
            {
                TempData["AdminResult"] = "Thêm bài học thành công!";
                return new JsonResult("Success");
            }
            else
            {
                TempData["AdminResult"] = "Thêm bài học thất bại!";
                return new JsonResult("Failed");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPostDeleteLesson(string MaBH, string MaKH)
        { 
            if(MaBH != null)
            {
                ResultReturn result = await new ExcuteJsonClass().deleteLesson(MaBH);
                TempData["MaKH"] = MaKH;
                if (result.message.Equals("success"))
                {
                    TempData["AdminResult"] = "Xóa thành công!";
                    return new JsonResult("Success");
                }
                else
                {
                    TempData["AdminResult"] = "Xóa thất bại!";
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
