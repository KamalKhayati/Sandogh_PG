using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class MasolinSandogh
    {
        public int Id { get; set; }
        public string MasolinName { get; set; }
        public string SematName { get; set; }
        public string MobilNumber { get; set; }
        //[Column(TypeName = "Date")]
        public string StartDate { get; set; }
        //[Column(TypeName = "Date")]
        public string EndDate { get; set; }
        public string Tozihat { get; set; }
        //public string Tozihat1 { get; set; }
        [Required]
        public int SandoghId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }

    }
}
