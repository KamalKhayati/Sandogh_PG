using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
    public class AazaSandogh
    {
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [MaxLength(40)]
        public string CodePersoneli { get; set; }
        [Required,Column(TypeName = "Date")]
        public DateTime TarikhOzviat { get; set; }
        [Required, MaxLength(100)]
        public string NameVFamil { get; set; }
        [MaxLength(40)]
        public string NamePedar { get; set; }
        [MaxLength(10)]
        public string CodeMelli { get; set; }
        [MaxLength(10)]
        public string ShShenasname { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        [MaxLength(5)]
        public string Jensiat { get; set; }
        public int? IndexJensiat { get; set; }
        [MaxLength(5)]
        public string Taahol { get; set; }
        public int? IndexTaahol { get; set; }
        [MaxLength(40)]
        public string NameBank { get; set; }
        [MaxLength(40)]
        public string ShomareHesab { get; set; }
        [MaxLength(40)]
        public string ShomareKart { get; set; }
        [MaxLength(40)]
        public string ShomareShaba { get; set; }
        [MaxLength(400)]
        public string AdressManzel { get; set; }
        [MaxLength(400)]
        public string AdressMohalKar { get; set; }
        [MaxLength(23)]
        public string Mobile1 { get; set; }
        [MaxLength(23)]
        public string Mobile2 { get; set; }
        [MaxLength(23)]
        public string Tell { get; set; }
        [MaxLength(40)]
        public string Shoghl { get; set; }
        [MaxLength(100)]
        public string Moaref { get; set; }
        public int? MoarefId { get; set; }
        public decimal? BesAvali { get; set; }
        //public decimal? BedAvali { get; set; }
        public decimal? HaghOzviat { get; set; }
        public decimal? HazineEftetah { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsOzveSandogh { get; set; }
        [MaxLength(400)]
        public string SharhHesab { get; set; }
        public byte[] Pictuer { get; set; }
        [Required]
        public int TarifSandoghId { get; set; }
        //public virtual TarifSandogh TarifSandogh1 { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        [Required]
        public int ShomareSanad { get; set; }
        //public virtual ICollection<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }
        //public virtual GroupTafzili GroupTafzili1 { get; set; }
        //public virtual ICollection<DaryaftNaghdiVBanki> DaryaftNaghdiVBankis { get; set; }
        //public virtual ICollection<PardakhtNaghdiVBanki> PardakhtNaghdiVBankis { get; set; }

    }
}
