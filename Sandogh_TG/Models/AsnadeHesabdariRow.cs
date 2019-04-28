using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class AsnadeHesabdariRow
    {
        public int Id { get; set; }
        [Required]
        public int ShomareSanad { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime Tarikh { get; set; }
        [Required]
        public int MoinCode { get; set; }
        [Required, MaxLength(50)]
        public string MoinName { get; set; }
        //[Required]
        //public int HesabTafId { get; set; }
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
    }
}
