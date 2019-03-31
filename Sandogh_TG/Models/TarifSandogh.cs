using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG.Models
{
   public class TarifSandogh
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string NameSandogh { get; set; }
        [MaxLength(150)]
        public string NameModir { get; set; }
        public float? Karmozd { get; set; }
        public int? Dirkard { get; set; }
        [MaxLength(400)]
        public string Adress { get; set; }
        [MaxLength(23)]
        public string Tell { get; set; }
        [MaxLength(23)]
        public string Mobile { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhEjad { get; set; }
        [MaxLength(400)]
        public string Path { get; set; }
        public byte[]  Pictuer { get; set; }

    }
}
