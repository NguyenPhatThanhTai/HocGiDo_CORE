using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ViewModels.Admin
{
    public class AddCourse
    {
        public string tenKH { get; set; }
        public string moTaKH { get; set; }
        public string mauSac { get; set; }
        public string maKH { get; set; }
        public IFormFile CourseImage { set; get; }
    }
}
