using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace HocGiDo_CORE.Pages
{
    public class codeModel : PageModel
    {
        public Lesson lesson { get; set; }
        public async Task<IActionResult> OnGet(string kh,string bh)
        {
            if(bh == null)
            {
                lesson = null;
                return Page();
            }
            else
            {
                ListLesson listLesson = await new ExcuteJsonClass().getLessonOfCourse(kh);
                lesson = listLesson.BaiHoc.FirstOrDefault(p => p.MaBaiHoc.Equals(bh));
                return Page();
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string CSharpCode)
        {
            try
            {
                StringWriter stringWriter = new StringWriter();

                Console.SetOut(stringWriter);

                await CSharpScript.EvaluateAsync(CSharpCode);

                string consoleOutput = stringWriter.ToString();

                return new JsonResult(new
                {
                    result = consoleOutput.ToString(),
                });
            }
            catch(Exception e)
            {
                return new JsonResult(new
                {
                    result = "Lỗi biên dịch",
                });
            }
        }
    }
}
