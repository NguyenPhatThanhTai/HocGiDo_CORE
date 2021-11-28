using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ModelsJson
{
    public class user
    {
        public string MaTK { get; set; }
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public bool Quyen { get; set; }
        public string MaND { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string HinhDaiDien { get; set; }
    }
}
