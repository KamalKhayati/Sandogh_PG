using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class GroupTafzili
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int SandoghId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
        public virtual ICollection<CodingDaramadVHazine> CodingDaramadVHazines { get; set; }
        public virtual ICollection<AazaSandogh> AazaSandoghs { get; set; }
        public virtual ICollection<HesabBanki> HesabBankis { get; set; }
        public virtual ICollection<AllHesabTafzili> AllHesabTafzilis { get; set; }

    }
}
