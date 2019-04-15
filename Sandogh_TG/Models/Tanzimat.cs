using Sandogh_TG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class Tanzimat
    {
        public int Id { get; set; }
        [Required]
        public int SandoghId { get; set; }
        public string SandoghName { get; set; }
        public float? DarsadeKarmozd { get; set; }
        public int? MablaghDirkard { get; set; }
        public int? MaximumAghsatMahane { get; set; }
        public int? MaximumAghsatSalane { get; set; }
        [MaxLength(400)]
        public string Path { get; set; }
        public bool checkEdit1 { get; set; }
        public bool checkEdit2 { get; set; }
        public bool checkEdit3 { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
    }
}
