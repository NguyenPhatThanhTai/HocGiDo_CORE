using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ModelsJson
{
    public class Question
    {
        public string MaCauHoi { get; set; }
        public string NoiDungCauHoi { get; set; }
        public string TheLoai { get; set; }

        public List<Answer> DapAn { get; set; }
    }
}
