using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ExcuteJson
{
    public class ApiContain
    {
        public String getUrlApi(String apiName)
        {
            var api = "";
            switch (apiName)
            {
                case "course":
                    api = "http://hocgido-api.gq/api/khoahoc";
                    break;
                case "user":
                    api = "https://hocgido-api.gq/api/nguoidung?MaTK=";
                    break;
                case "login":
                    api = "https://hocgido-api.gq/api/dangnhap";
                    break;
                case "lesson":
                    api = "https://hocgido-api.gq/api/baihoc?MaKH=";
                    break;
                default:
                    return null;
                    break;
            }
            return api;
        }
    }
}
