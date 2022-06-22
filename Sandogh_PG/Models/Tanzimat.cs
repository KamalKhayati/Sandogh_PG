using Sandogh_PG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
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
        public int XBrabarSarmaye { get; set; }
        public decimal MazrabEtebar { get; set; }
        [MaxLength(400)]
        public string Path { get; set; }
        public bool checkEdit1 { get; set; }
        public bool checkEdit2 { get; set; }
        public bool checkEdit3 { get; set; }
        public bool checkEdit4 { get; set; }
        public bool checkEdit5 { get; set; }
        public bool checkEdit6 { get; set; }
        public bool checkEdit7 { get; set; }
        public bool checkEdit8 { get; set; }
        [Required]
        public int MoinDefaultId { get; set; }
        [Required]
        public int TafsiliDefaultId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
    }
}
