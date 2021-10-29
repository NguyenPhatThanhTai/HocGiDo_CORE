﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HocGiDo_CORE.ExcuteJson;
using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HocGiDo_CORE.Pages
{
    public class dangnhapModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("Logined");
            Response.Cookies.Delete("Remember");
            return Page();
        }

        [BindProperty]
        public LoginVM login { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["LoginResult"] = "Vui lòng điền đầy đủ thông tin!";
                return Page();
            }

            ResultReturn result = await new ExcuteJsonClass().Login(login);
            if (result == null || result.message.Equals("error"))
            {
                ViewData["LoginResult"] = "Sai tài khoản hoặc mật khẩu, vui lòng kiểm tra lại";
                return Page();
            }
            else
            {
                var userInf = await new ExcuteJsonClass().getUser(result.message);
                HttpContext.Session.SetString("Logined", JsonConvert.SerializeObject(userInf));

                if (login.Keeplogin.Equals("true"))
                {
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("Remember", JsonConvert.SerializeObject(userInf), option);
                }
                return RedirectToPage("/Index");
            }
        }
    }
}
