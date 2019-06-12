using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
    public class CodingAmval
    {
        public int Id { get; set; }
        [Required]
        public int SandoghId { get; set; }
        [Required]
        public int Code { get; set; }
        //[Required]
        //public int GroupIndex { get; set; }
        //[Required, MaxLength(10)]
        //public string GroupName { get; set; }
        [MaxLength(100)]
        public string HesabName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        //public virtual TarifSandogh TarifSandogh1 { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        public int AllTafId { get; set; }
        //public virtual ICollection<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }
        //public virtual GroupTafzili GroupTafzili1 { get; set; }
    }
}
