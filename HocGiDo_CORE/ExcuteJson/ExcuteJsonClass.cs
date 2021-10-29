﻿using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ExcuteJson
{
    public class ExcuteJsonClass
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<Course> getCourse()
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("course"));
            var resp = JsonConvert.DeserializeObject<Course>(responseString);
            return resp;
        }

        public async Task<UserInf> getUser(string MaTK)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("user") + MaTK);
            var resp = JsonConvert.DeserializeObject<UserInf>(responseString);
            return resp;
        }

        public async Task<ResultReturn> Login(LoginVM login)
        {
            var data = new Dictionary<string, string>
                {
                    {"tenTK",""+login.UserName+""},
                    {"matKhau",""+login.Passworld+""}
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("login"), contentData);

            System.Diagnostics.Debug.WriteLine("O day ================= " + new ApiContain().getUrlApi("login"));

            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultReturn>(stringData);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<ResultReturn> Register(RegisterVM register)
        {
            var data = new Dictionary<string, string>
                {
                    {"tenTK",""+register.User+""},
                    {"matKhau",""+register.Passworld+""},
                    {"hoTen",""+register.UserName+""},
                    {"ngaySinh",""+register.Birth.ToString("yyyy-MM-dd")+""},
                    {"sdt",""+register.PhoneNum+""},
                    {"diaChi",""+register.Address+""},
                    {"email",""+register.Email+""}
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("register"), contentData);

            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultReturn>(stringData);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<ListLesson> getLessonOfCourse(string MaKH)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("lesson") + MaKH);
            var resp = JsonConvert.DeserializeObject<ListLesson>(responseString);
            return resp;
        }

        public async Task<ListQuestion> getIdExamOfLesson(string MaBH)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("ExamId") + MaBH);
            var resp = JsonConvert.DeserializeObject<ResultReturn>(responseString);

            if (resp.message != null)
            {
                var responseStringExam = await client.GetStringAsync(new ApiContain().getUrlApi("ListExam") + resp.message);
                var respExam = JsonConvert.DeserializeObject<ListQuestion>(responseStringExam);
                return respExam;
            }
            else
            {
                return null;
            }
        }

        public async Task<ResultReturn> checkRegisterCourse(string MaKH, string MaND)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("checkRegisterCourse") + "?MaKH=" + MaKH + "&MaND=" + MaND);
            var resp = JsonConvert.DeserializeObject<ResultReturn>(responseString);

            return resp;
        }

        public async Task<ResultReturn> registerCourse(string MaKH, string MaND)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("registerCourse") + "?MaKH=" + MaKH + "&MaND=" + MaND);
            var resp = JsonConvert.DeserializeObject<ResultReturn>(responseString);

            return resp;
        }

        public async Task<ListCourseRegisted> getListCourseRegisted(string MaND)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("getListCourseRegisted") + MaND);
            var resp = JsonConvert.DeserializeObject<ListCourseRegisted>(responseString);

            return resp;
        }
    }
}
