using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class AllHesabTafzili
    {
        public int Id { get; set; }
        [Required]
        public int Id2 { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int SandoghId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
        public virtual GroupTafzili GroupTafzili1 { get; set; }
        //public virtual ICollection<VamPardakhti> VamPardakhtis { get; set; }
        //public virtual ICollection<HaghOzviat> HaghOzviats { get; set; }
        public virtual ICollection<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }
        public virtual ICollection<CheckTazmin> CheckTazmins { get; set; }
        //public virtual ICollection<VamPardakhti> VamPardakhtis { get; set; }
        public virtual ICollection<R_VamPardakhti_B_Zamenin> R_VamPardakhti_B_Zamenins { get; set; }

    }
}
