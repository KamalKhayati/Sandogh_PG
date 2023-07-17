using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
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
        //[MaxLength(10)]
        public int ShomareDarkhast { get; set; }
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
        //[Required]
        public decimal? MandeVam { get; set; }
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
        [MaxLength(200)]
        public string ZameninId { get; set; }
        [MaxLength(500)]
        public string ZameninName { get; set; }
        //[MaxLength(500)]
        //public string ZameninCode { get; set; }
        public bool? HaveCheckTazmin { get; set; }
        public bool? IsTasviye { get; set; }
        [Required]
        public int ShomareSanad { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        [MaxLength(500)]
        public string Tozihat { get; set; }
        public virtual AllHesabTafzili AllHesabTafzili1 { get; set; }
        public virtual ICollection<RizeAghsatVam> RizeAghsatVams { get; set; }
        public virtual ICollection<R_VamPardakhti_B_Zamenin> R_VamPardakhti_B_Zamenins { get; set; }
        public virtual ICollection<R_VamPardakhti_B_CheckTazmin> R_VamPardakhti_B_CheckTazmins { get; set; }
    }

    public class R_VamPardakhti_B_Zamenin
    {
        [Key]
        [Required, Column(Order = 0)]
        public int VamPardakhtiId { get; set; }
        [Key]
        [Required, Column(Order = 1)]
        public int AllTafId { get; set; }
        [Required, Column(Order = 2)]
        public decimal EtebarBlookeShode { get; set; }
        [Required, Column(Order = 3)]
        public int SalMaliId { get; set; }
        public virtual VamPardakhti VamPardakhtin1 { get; set; }
        public virtual AllHesabTafzili AllHesabTafzili1 { get; set; }

    }

    public class R_VamPardakhti_B_CheckTazmin
    {
        [Key]
        [Required, Column(Order = 0)]
        public int VamPardakhtiId { get; set; }
        [Key]
        [Required, Column(Order = 1)]
        public int CheckTazminId { get; set; }
        [Required, Column(Order = 2)]
        public decimal MablageCheck { get; set; }
        [Required, Column(Order = 3)]
        public int SalMaliId { get; set; }
        public virtual VamPardakhti VamPardakhtin1 { get; set; }
        public virtual CheckTazmin CheckTazmin1 { get; set; }

    }

}
