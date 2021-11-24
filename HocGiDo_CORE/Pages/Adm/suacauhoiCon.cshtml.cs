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
        public string MaBH { get; set; }
        public async Task<IActionResult> OnGet(string bh, string questId)
        {
            MaCH = questId;
            MaBH = bh;
            listQuestion = await new ExcuteJsonClass().getIdExamOfLesson(bh);
            question = listQuestion.CauHoi.FirstOrDefault(p => p.MaCauHoi.Equals(questId));
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAddAnswer([FromBody]AddExam exam)
        {
            if(exam.TenDapAn != null && exam.MaCH != null)
            {
                ResultReturn result = await new ExcuteJsonClass().addNewAnswer(exam.TenDapAn, false, exam.MaCH);

                if(result.message.Equals("success"))
                {
                    return new JsonResult("Success");
                }
                else
                {
                    return new JsonResult("Failed");
                }
            }
            else
            {
                return new JsonResult("Failed");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDeleteAnswer(string answerId)
        {
            if(answerId != null)
            {
                ResultReturn result = await new ExcuteJsonClass().deleteAnswer(answerId);

                if (result.message.Equals("success"))
                {
                    return new JsonResult("Success");
                }
                else
                {
                    return new JsonResult("Failed");
                }
            }
            else
            {
                return new JsonResult("Failed");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostUpdateExam(string questName, AddExam[] listAnswer, string trueAnswer, string MaCH)
        {
            if(questName != null && listAnswer.Length > 0 && trueAnswer != null && MaCH != null)
            {
                //update name of question first
                ResultReturn updateNameQuestion = await new ExcuteJsonClass().updateExam(MaCH, questName, "tracnghiem");
                bool checkUpdate = true;

                //update answer
                foreach (var item in listAnswer)
                {
                    bool trueAnswered = false;
                    if (item.MaDA.Equals(trueAnswer))
                    {
                        trueAnswered = true;
                    }
                    ResultReturn updateAnswer = await new ExcuteJsonClass().updateAnswer(item.MaDA, item.TenDapAn, trueAnswered);
                    if (!updateAnswer.message.Equals("success"))
                    {
                        checkUpdate = false;
                    }
                }

                if (updateNameQuestion.message.Equals("success") && checkUpdate)
                {
                    return new JsonResult("Success");
                }
                else
                {
                    return new JsonResult("Failed");
                }
            }
            else
            {
                return new JsonResult("Failed");
            }
        }
    }
}
