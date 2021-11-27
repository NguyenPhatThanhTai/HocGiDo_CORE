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
            var host = "https://hocgido-api.gq/";
            switch (apiName)
            {
                case "course":
                    api ="api/khoahoc";
                    break;
                case "user":
                    api = "api/nguoidung?MaTK=";
                    break;
                case "login":
                    api = "api/dangnhap";
                    break;
                case "register":
                    api = "api/dangki";
                    break;
                case "lesson":
                    api = "api/baihoc?MaKH=";
                    break;
                case "ExamId":
                    api = "api/kiemtra?MaBaiHoc=";
                    break;
                case "ListExam":
                    api = "api/cauhoi?MaKT=";
                    break;
                case "checkRegisterCourse":
                    api = "api/kiemtradangkikhoahoc"; // two parameters
                    break;
                case "registerCourse":
                    api = "api/dangkikhoahocmoi"; // two parameters
                    break;
                case "getListCourseRegisted":
                    api = "api/danhsachkhoahocdangki?MaND=";
                    break;
                case "saveLesson":
                    api = "api/luubaihocmoi"; // two parameters
                    break;
                case "checkSaveLesson":
                    api = "api/kiemtraluubaihoc"; //two parameters
                    break;
                case "getListSavedLesson":
                    api = "api/danhsachluubaihoc?MaND=";
                    break;
                case "getListComment":
                    api = "api/binhluan?MaBaiHoc=";
                    break;
                case "sendComment":
                    api = "api/binhluanmoi";
                    break;

                //admin

                case "addCourse":
                    api = "api/themkhoahocmoi";
                    break;
                case "updateCourse":
                    api = "api/suakhoahoc";
                    break;
                case "deleteCourse":
                    api = "api/xoakhoahoc";
                    break;
                case "addLesson":
                    api = "api/thembaihocmoi";
                    break;
                case "deleteLesson":
                    api = "api/xoabaihoc";
                    break;
                case "updateLesson":
                    api = "api/suabaihoc";
                    break;
                case "addNewQuestion":
                    api = "api/themcauhoimoi";
                    break;
                case "addNewAnswer":
                    api = "api/themdapanmoi";
                    break;
                case "deleteAnswer":
                    api = "api/xoadapan";
                    break;
                case "updateQuestion":
                    api = "api/suacauhoi";
                    break;
                case "updateAnswer":
                    api = "api/suadapan";
                    break;
                case "deleteExam":
                    api = "api/xoacauhoi";
                    break;
                case "listUser":
                    api = "api/tatcanguoidung";
                    break;
                default:
                    return null;
            }
            return host + api;
        }
    }
}
