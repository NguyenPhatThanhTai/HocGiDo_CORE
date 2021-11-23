using HocGiDo_CORE.ModelsJson;
using HocGiDo_CORE.ViewModels;
using HocGiDo_CORE.ViewModels.Admin;
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

        public async Task<ResultReturn> saveLesson(string MaBH, string MaND)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("saveLesson") + "?MaBaiHoc=" + MaBH + "&MaND=" + MaND);
            var resp = JsonConvert.DeserializeObject<ResultReturn>(responseString);

            return resp;
        }

        public async Task<ResultReturn> checkSaveLesson(string MaBH, string MaND)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("checkSaveLesson") + "?MaBaiHoc=" + MaBH + "&MaND=" + MaND);
            var resp = JsonConvert.DeserializeObject<ResultReturn>(responseString);

            return resp;
        }

        public async Task<ListSavedLesson> getListSavedLesson(string MaND)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("getListSavedLesson") + MaND);
            var resp = JsonConvert.DeserializeObject<ListSavedLesson>(responseString);

            return resp;
        }

        public async Task<ListComment> getListComment(string MaBH)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("getListComment") + MaBH);
            var resp = JsonConvert.DeserializeObject<ListComment>(responseString);

            return resp;
        }

        public async Task<ResultReturn> sendComment(CommentVM cmt)
        {
            var data = new Dictionary<string, string>
                {
                    {"noiDung",""+cmt.noiDung+""},
                    {"maND",""+cmt.maND+""},
                    {"maBaiHoc",""+cmt.maBaiHoc+""}
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("sendComment"), contentData);

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

        public async Task<ResultReturn> addCourse(AddCourse addCourse)
        {
            var data = new Dictionary<string, string>
                {
                    {"tenKH",""+addCourse.tenKH+""},
                    {"moTaKH",""+addCourse.moTaKH+""},
                    {"mauSac",""+addCourse.mauSac+""}
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("addCourse"), contentData);

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

        public async Task<ResultReturn> updateCourse(UpdateCourse updateCourse)
        {
            var data = new Dictionary<string, string>
                {
                    {"maKH",""+updateCourse.MaKHUpdate+""},
                    {"tenKH",""+updateCourse.TenKHUpdate+""},
                    {"moTaKH",""+updateCourse.MoTaKHUpdate+""},
                    {"mauSac",""+updateCourse.MauSacUpdate+""}
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("updateCourse"), contentData);

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

        public async Task<ResultReturn> deleteCourse(string MaKH)
        {
            var data = new Dictionary<string, string>
                {
                    {"maKH",""+MaKH+""},
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("deleteCourse"), contentData);

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

        public async Task<ResultReturn> addLesson(Lesson lesson)
        {
            var data = new Dictionary<string, string>
                {
                    {"maKH",""+lesson.MaKH+""},
                    {"tenBaiHoc",""+lesson.TenBaiHoc+""},
                    {"video",""+lesson.Video+""},
                    {"gioiThieu",""+lesson.GioiThieu+""},
                    {"lyThuyet",""+lesson.LyThuyet+""},
                    {"codeMau",""+lesson.CodeMau+""},
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("addLesson"), contentData);

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

        public async Task<ResultReturn> deleteLesson(string MaBH)
        {
            var data = new Dictionary<string, string>
                {
                    {"maBaiHoc",""+MaBH+""},
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("deleteLesson"), contentData);

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

        public async Task<ResultReturn> updateLesson(Lesson lesson)
        {
            var data = new Dictionary<string, string>
                {
                    {"maBaiHoc",""+lesson.MaBaiHoc+""},
                    {"tenBaiHoc",""+lesson.TenBaiHoc+""},
                    {"video",""+lesson.Video+""},
                    {"gioiThieu",""+lesson.GioiThieu+""},
                    {"lyThuyet",""+lesson.LyThuyet+""},
                    {"codeMau",""+lesson.CodeMau+""},
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("updateLesson"), contentData);

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

        public async Task<ResultReturn> addQuestion(string QuestName, string type, string MaBH)
        {
            var responseString = await client.GetStringAsync(new ApiContain().getUrlApi("ExamId") + MaBH);
            var resp = JsonConvert.DeserializeObject<ResultReturn>(responseString);

            var data = new Dictionary<string, string>
                {
                    {"noiDungCauHoi",""+QuestName+""},
                    {"theLoai",""+type+""},
                    {"maKT",""+resp.message+""}
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("addNewQuestion"), contentData);

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

        public async Task<ResultReturn> addNewAnswer(string TenDapAn, bool DapAnDung, string MaCauHoi)
        {
            var data = new Dictionary<string, object>
                {
                    {"noiDungDapAn",""+TenDapAn+""},
                    {"dapAnDung",DapAnDung},
                    {"maCauHoi",""+MaCauHoi+""}
                };

            var jsonData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new ApiContain().getUrlApi("addNewAnswer"), contentData);

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
    }
}
