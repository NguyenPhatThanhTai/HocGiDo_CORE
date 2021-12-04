using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ViewModels
{
    public class RegisterVM
    {
        public string User { get; set; }
        public string Passworld { get; set; }
        public string UserName { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
