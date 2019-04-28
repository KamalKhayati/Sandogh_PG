using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class CodeMoin
    {
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int SalMaliId { get; set; }

    }
}
