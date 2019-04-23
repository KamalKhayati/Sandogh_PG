using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class EnteghalatHesabBanki
    {
        public int Id { get; set; }
        [Required]
        public int Seryal { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime Tarikh { get; set; }
        [Required]
        public decimal Mablagh { get; set; }
        [Required]
        public int HesabBanki1Id { get; set; }
        [Required, MaxLength(100)]
        public string HesabBanki1Name { get; set; }
        [Required]
        public int HesabBanki2Id { get; set; }
        [Required, MaxLength(100)]
        public string HesabBanki2Name { get; set; }
        [MaxLength(200)]
        public string Sharh { get; set; }
        [Required]
        public int SalMaliId { get; set; }
    }
}
