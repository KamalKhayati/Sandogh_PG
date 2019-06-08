using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class TarifSandogh
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string NameSandogh { get; set; }
        [MaxLength(150)]
        public string NameModir { get; set; }
        [MaxLength(400)]
        public string Adress { get; set; }
        [MaxLength(23)]
        public string Tell { get; set; }
        [MaxLength(23)]
        public string Mobile { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TarikhEjad { get; set; }
        [MaxLength(10)]
        public string MadarBoardCode { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TarikhRegister { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TarikhEtmamGaranti { get; set; }
        public byte[]  Pictuer { get; set; }
        public byte[]  PicBackground { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [Required]
        public bool AppActived { get; set; }
        public virtual Tanzimat Tanzimat1 { get; set; }
        public virtual ICollection<SalMali> SalMalis { get; set; }
        //public virtual ICollection<AazaSandogh> AazaSandoghs { get; set; }
        //public virtual ICollection<HesabBanki> HesabBankis { get; set; }
        //public virtual ICollection<CodingDaramadVHazine> CodingDaramadVHazines { get; set; }
        public virtual ICollection<CodeMoin> CodeMoins { get; set; }
        public virtual ICollection<GroupTafzili> GroupTafzilis { get; set; }
        public virtual ICollection<AllHesabTafzili> AllHesabTafzilis { get; set; }
        //public virtual ICollection<Karbaran> Karbarans { get; set; }
    }
}
