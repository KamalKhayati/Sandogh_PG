using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class DaryaftPardakhtBinHesabha
    {
        public int Id { get; set; }
        [Required]
        public int Seryal { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime Tarikh { get; set; }
        [Required]
        public decimal Mablagh { get; set; }
        [Required]
        public int HesabMoinCode1 { get; set; }
        [Required, MaxLength(50)]
        public string HesabMoineName1 { get; set; }
        [Required]
        public int HesabTafziliCode1 { get; set; }
        [Required, MaxLength(50)]
        public string HesabTafziliName1 { get; set; }
        [Required]
        public int HesabMoinCode2 { get; set; }
        [Required, MaxLength(50)]
        public string HesabMoineName2 { get; set; }
        [Required]
        public int HesabTafziliCode2 { get; set; }
        [Required, MaxLength(50)]
        public string HesabTafziliName2 { get; set; }
        [MaxLength(200)]
        public string Sharh { get; set; }
        [Required]
        public int ShomareSanad { get; set; }
        [Required]
        public int SalMaliId { get; set; }
    }
}
