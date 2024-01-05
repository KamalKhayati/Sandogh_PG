using Sandogh_PG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class Tanzimat
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int SandoghId { get; set; }
        public string SandoghName { get; set; }
        //public float? DarsadeKarmozd { get; set; }
        //public int? MablaghDirkard { get; set; }
        //public int? MaximumAghsatMahane { get; set; }
        //public int? MaximumAghsatSalane { get; set; }
        //public int ModatEntezar { get; set; }
        //public decimal MazrabEtebar { get; set; }
        [MaxLength(400)]
        public string Path { get; set; }
        public bool checkEdit1 { get; set; }
        public bool checkEdit2 { get; set; }
        public bool checkEdit3 { get; set; }
        public bool checkEdit4 { get; set; }
        public bool checkEdit5 { get; set; }
        public bool checkEdit6 { get; set; }
        public bool checkEdit10 { get; set; }
        public int XMah { get; set; }
        public bool checkEdit11 { get; set; }
        public bool checkEdit12 { get; set; }
        public bool checkEdit13 { get; set; }
        public bool checkEdit14 { get; set; }
        public bool checkEdit18 { get; set; }
        public bool checkEdit16 { get; set; }
        public bool checkEdit17 { get; set; }
        public int radioGroup1 { get; set; }
        public int radioGroup2 { get; set; }
        public int radioGroup3 { get; set; }
        public int radioGroup4 { get; set; }

        public decimal MinMablaghSarmayeAvalye { get; set; }
        public decimal MaxMablaghSarmayeAvalye { get; set; }

        public decimal MablaghHarSahm { get; set; }
        public double MinTedadSahm { get; set; }
        public double MaxTedadSahm { get; set; }

        public decimal MinMablaghPasandaz { get; set; }
        public decimal MaxMablaghPasandaz { get; set; }

        public double MinDarsadPasandaz { get; set; }
        public double MaxDarsadPasandaz { get; set; }

        [Required]
        public int MoinDefaultId { get; set; }
        public int NoeRezervIndex { get; set; }
        [Required]
        public int TafsiliDefaultId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
        public virtual ICollection<AnvaeVam> AnvaeVams { get; set; }

    }
}
