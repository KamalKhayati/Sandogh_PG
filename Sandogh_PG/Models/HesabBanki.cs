using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class HesabBanki
    {
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(200)]
        public string NameHesab { get; set; }
        [Required]
        public int GroupHesabIndex { get; set; }
        [Required, MaxLength(5)]
        public string GroupHesab { get; set; }
        [Required, MaxLength(40)]
        public string NameBank { get; set; }
        [MaxLength(40)]
        public string NameShobe { get; set; }
        public float CodeShobe { get; set; }
        [MaxLength(40)]
        public string NoeHesab { get; set; }
        [MaxLength(40)]
        public string ShomareHesab { get; set; }
        [MaxLength(40)]
        public string ShomareKart { get; set; }
        [MaxLength(40)]
        public string ShomareShaba { get; set; }
        [MaxLength(40)]
        public string ShomareMoshtari { get; set; }
        //public decimal? Mojodi { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [MaxLength(23)]
        public string Tell { get; set; }
        [Required]
        public int TarifSandoghId { get; set; }
        //public virtual TarifSandogh TarifSandogh1 { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        public int AllTafId { get; set; }
        //public virtual GroupTafzili GroupTafzili1 { get; set; }
        //public virtual ICollection<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }

    }
}
