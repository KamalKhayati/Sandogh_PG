using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class VamPardakhti
    {
        public int Id { get; set; }
        [Required]
        public int AazaId { get; set; }
        [Required, MaxLength(150)]
        public string NameAaza { get; set; }
        [Required]
        public int IndexNahveyePardakht { get; set; }
        [Required, MaxLength(15)]
        public string NahveyePardakht { get; set; }
        [Required]
        public int IndexNoeVam { get; set; }
        [Required, MaxLength(15)]
        public string NoeVam { get; set; }
        public float? DarsadeKarmozd { get; set; }
        public int? MablaghDirkard { get; set; }
        public bool checkEdit1 { get; set; }
        public bool checkEdit2 { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhDarkhast { get; set; }
        [MaxLength(10)]
        public string ShomareDarkhast { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime TarikhPardakht { get; set; }
        [Required]
        public decimal MablaghAsli { get; set; }
        public decimal MablaghKarmozd { get; set; }
        [Required]
        public int IndexFaseleAghsat { get; set; }
        [Required, MaxLength(10)]
        public string FaseleAghsat { get; set; }
        [Required]
        public int TedadAghsat { get; set; }
        [Required]
        public decimal MablaghAghsat { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime SarresidAvalinGhest { get; set; }
        [Required]
        public int HesabMoinId { get; set; }
        [Required, MaxLength(50)]
        public string HesabMoinName { get; set; }
        [Required]
        public int HesabTafziliId { get; set; }
        [Required, MaxLength(200)]
        public string HesabTafziliName { get; set; }
        [MaxLength(25)]
        public string ZameninId { get; set; }
        [MaxLength(150)]
        public string ZameninName { get; set; }
        public bool? HaveCheckTazmin { get; set; }
        public bool? IsTasviye { get; set; }
        [Required]
        public int ShomareSanad { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public virtual AllHesabTafzili AllHesabTafzili1 { get; set; }
        public virtual ICollection<RizeAghsatVam> RizeAghsatVams { get; set; }
    }
}
