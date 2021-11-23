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
    public class suacauhoiConModel : PageModel
    {
        public ListQuestion listQuestion { get; set; }
        public Question question { get; set; }
        public string MaCH { get; set; }
        public async Task<IActionResult> OnGet(string bh, string questId)
        {
            MaCH = questId;
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(bh);
            return Page();
        }

        [BindProperty]
        public AddExam exam { get; set; }
        public async Task<IActionResult> OnPostAddAnswer()
        {
            if(exam.TenDapAn != null && exam.MaCH != null)
            {
                bool trueAnswer = false;
                if(exam.DapAnDung != null)
                {
                    trueAnswer = true;
                }

                ResultReturn result = await new ExcuteJsonClass().addNewAnswer(exam.TenDapAn, trueAnswer, exam.MaCH);

                if(result.message.Equals("success"))
                {
                    TempData["AdminResult"] = "Thêm câu trả lời thành công!";
                    TempData["MaBH"] = exam.MaBH;
                    return RedirectToPage("/Adm/quanlybaihoc");
                }
                else
                {
                    TempData["AdminResult"] = "Thêm câu trả lời thất bại!";
                    TempData["MaBH"] = exam.MaBH;
                    return RedirectToPage("/Adm/quanlybaihoc");
                }
            }
            else
            {
                TempData["AdminResult"] = "Thất bại!";
                TempData["MaBH"] = exam.MaBH;
                return RedirectToPage("/Adm/quanlybaihoc");
            }
        }
    }
}
