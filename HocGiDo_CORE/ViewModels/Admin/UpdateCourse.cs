using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ViewModels.Admin
{
    public class UpdateCourse
    {
        public string MaKHUpdate { get; set; }
        public string TenKHUpdate { get; set; }
        public string MoTaKHUpdate { get; set; }
        public string MauSacUpdate { get; set; }
        public IFormFile CourseImageUpdate { set; get; }
    }
}
