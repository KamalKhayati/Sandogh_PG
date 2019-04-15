using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class HaghOzviat
    {
        public int Id { get; set; }
        [Required]
        public int AazaId { get; set; }
        [Required]
        public int Seryal { get; set; }
        [Required,Column(TypeName = "Date")]
        public DateTime Tarikh { get; set; }
        [Required]
        public decimal Mablagh { get; set; }
        [Required]
        public int NameHesabId { get; set; }
        [Required, MaxLength(200)]
        public string NameHesab { get; set; }
        [Required]
        public int IndexMonth { get; set; }
        [Required,MaxLength(10)]
        public string Month { get; set; }
        [Required]
        public int Sal { get; set; }
        [MaxLength(150)]
        public string Sharh { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public virtual AazaSandogh AazaSandogh1 { get; set; }
        public virtual HesabBanki HesabBanki1 { get; set; }
    }
}
