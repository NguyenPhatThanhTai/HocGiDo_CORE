using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HocGiDo_CORE.Pages.Adm
{
    public class quanlycauhoiConModel : PageModel
    {
        public ListQuestion listQuestion { get; set; }
        public string lessonId { get; set; }
        public async Task <IActionResult> OnGet(string bh)
        {
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(bh);
            lessonId = bh;
            return Page();
        }

        [BindProperty]
        public AddExam exam { get; set; }
        public async Task<IActionResult> OnPostAddExam()
        {
            if(exam.TenCauHoi != null && exam.MaBH != null)
            {
                ResultReturn result = await new ExcuteJsonClass().addQuestion(exam.TenCauHoi, "tracnghiem", exam.MaBH);
                if(result.message.Equals("success"))
                {
                    TempData["AdminResult"] = "Thêm câu hỏi thành công!";
                    TempData["MaBH"] = exam.MaBH;
                    return RedirectToPage("/Adm/quanlybaihoc");
                }
                else
                {
                    TempData["AdminResult"] = "Thêm câu hỏi thành công!";
                    TempData["MaBH"] = exam.MaBH;
                    return RedirectToPage("/Adm/quanlybaihoc");
                }
            }
            else
            {
                TempData["AdminResult"] = "Có lỗi xảy ra!";
                TempData["MaBH"] = exam.MaBH;
                return RedirectToPage("/Adm/quanlybaihoc");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDeleteExam(string MaCH, string MaBH)
        {
            if(MaCH != null && MaBH != null)
            {
                ResultReturn result = await new ExcuteJsonClass().deleteExam(MaCH);
                if (result.message.Equals("success"))
                {
                    TempData["AdminResult"] = "Xóa câu hỏi thành công!";
                    TempData["MaBH"] = MaBH;
                    return new JsonResult("Success");
                }
                else
                {
                    TempData["AdminResult"] = "Xóa câu hỏi thất bại!";
                    TempData["MaBH"] = MaBH;
                    return new JsonResult("Failed");
                }
            }
            else
            {
                TempData["AdminResult"] = "Có lỗi xảy ra!";
                TempData["MaBH"] = MaBH;
                return new JsonResult("Failed");
            }
        }
    }
}
