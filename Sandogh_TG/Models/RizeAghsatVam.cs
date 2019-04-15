using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class RizeAghsatVam
    {
        public int Id { get; set; }
        [Required]
        public int VamPardakhtiId { get; set; }
        [Required]
        public int VamPardakhtiCode { get; set; }
        [Required]
        public int ShomareGhest { get; set; }
        [Required,Column(TypeName = "Date")]
        public DateTime TarikhSarresid { get; set; }
        [Required]
        public decimal MablaghAghsat { get; set; }
        public int SeryalDaryaft { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhDaryaft { get; set; }
        public decimal MablaghDaryafti { get; set; }
        public int NameHesabId { get; set; }
        [MaxLength(200)]
        public string NameHesab { get; set; }
        [MaxLength(300)]
        public string Sharh { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public virtual VamPardakhti VamPardakhti1 { get; set; }

    }
}
