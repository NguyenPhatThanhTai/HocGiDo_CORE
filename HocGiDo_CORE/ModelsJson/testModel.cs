using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.ModelsJson
{
    public class testModel
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }

        [Required, StringLength(10)]
        public string FullName { get; set; }
    }
}
