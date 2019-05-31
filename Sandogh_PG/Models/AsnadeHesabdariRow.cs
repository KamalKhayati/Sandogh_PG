using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class AsnadeHesabdariRow
    {
        public int Id { get; set; }
        [Required]
        public int ShomareSanad { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime Tarikh { get; set; }
        [Required]
        public int HesabMoinId { get; set; }
        [Required]
        public int HesabMoinCode { get; set; }
        [Required, MaxLength(50)]
        public string HesabMoinName { get; set; }
        [Required]
        public int HesabTafId { get; set; }
        [Required]
        public int HesabTafCode { get; set; }
        [Required,MaxLength(50)]
        public string HesabTafName { get; set; }
        public decimal? Bed { get; set; }
        public decimal? Bes { get; set; }
        [MaxLength(150)]
        public string Sharh { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public virtual SalMali SalMali1 { get; set; }
        public virtual CodeMoin CodeMoin1 { get; set; }
        public virtual AllHesabTafzili AllHesabTafzili1 { get; set; }
        //public virtual HesabBanki HesabBanki1 { get; set; }
        //public virtual AazaSandogh AazaSandogh1 { get; set; }
        //public virtual CodingDaramadVHazine CodingDaramadVHazine1 { get; set; }

    }
}
