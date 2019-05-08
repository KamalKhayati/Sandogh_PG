using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class Karbaran
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Shenase { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        //[Required]
        //public int SandoghId { get; set; }
        //public virtual TarifSandogh TarifSandogh1 { get; set; }
    }
}
