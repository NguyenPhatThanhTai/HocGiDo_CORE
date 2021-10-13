using HocGiDo_CORE.ModelsJson;
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
    }
}
