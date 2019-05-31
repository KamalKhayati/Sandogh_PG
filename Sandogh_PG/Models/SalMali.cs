using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class SalMali
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int SaleMali { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [Required,MaxLength(150)]
        public string NameSandogh { get; set; }
        [Required]
        public int TarifSandoghId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
        public virtual ICollection<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }
        public virtual ICollection<CheckTazmin> CheckTazmins { get; set; }
    }
}
