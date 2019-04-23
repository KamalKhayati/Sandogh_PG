using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class SabDaramad
    {
        public int Id { get; set; }
        [Required]
        public int Seryal { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime Tarikh { get; set; }
        [Required]
        public int DaramadId { get; set; }
        [Required, MaxLength(100)]
        public string DaramadName { get; set; }
        [Required]
        public decimal Mablagh { get; set; }
        [Required]
        public int HesabBankiId { get; set; }
        [Required,MaxLength(100)]
        public string HesabBankiName { get; set; }
        [MaxLength(200)]
        public string Sharh { get; set; }
        [Required]
        public int SandoghId { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
    }
}
