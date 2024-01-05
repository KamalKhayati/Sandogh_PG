using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
    public class AnvaeVam
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int NoeVamIndex { get; set; }
        [Required, MaxLength(100)]
        public string NoeVamName { get; set; }
        [Required]
        public double DarsadeKarmozd { get; set; }
        [Required]
        public double MablaghVamChandBrabarSarmaye { get; set; }
        //[Required, Column(TypeName = "Date")]
        //public DateTime Tarikh { get; set; }
        [Required]
        public decimal MablaghDirkard { get; set; }
        [Required]
        public decimal MaxPardakht { get; set; }
        [Required]
        public int MaxAghsatMahane { get; set; }
        [Required]
        public int MaxAghsatSalane { get; set; }
        //[Required, MaxLength(200)]
        //public string NameHesab { get; set; }
        [Required]
        public int MinModatEntezar { get; set; }
        //[Required, MaxLength(10)]
        //public string Month { get; set; }
        //[Required]
        //public int Sal { get; set; }
        //[MaxLength(150)]
        //public string Sharh { get; set; }
        //[Required]
        //public int SalMaliId { get; set; }
        [Required]
        public bool DefaultNoeVam { get; set; }
        public bool AdamEtayeVamJadid { get; set; }

        [Required]
        public int TanzimatId { get; set; }

        public virtual Tanzimat Tanzimat1 { get; set; }
        public virtual ICollection<TedadZamenin> TedadZamenins { get; set; }
        public virtual ICollection<R_AnvaeVam_B_AllHesabTafzili> R_AnvaeVam_B_AllHesabTafzilis { get; set; }
    }


    public class R_AnvaeVam_B_AllHesabTafzili
    {
        [Key]
        [Required, Column(Order = 0)]
        public int AllHesabTafziliId { get; set; }
        [Key]
        [Required, Column(Order = 1)]
        public int AnvaeVamId { get; set; }
        [Required, Column(Order = 2)]
        public int ShomareNobat { get; set; }
        [Required, Column(Order = 3)]
        public DateTime TarikhOzviat { get; set; }
        [Required, Column(Order = 4)]
        public DateTime TarikhNobat { get; set; }
        [Required, Column(Order = 5)]
        public int SalMaliId { get; set; }
        public virtual AnvaeVam AnvaeVam1 { get; set; }
        public virtual AllHesabTafzili AllHesabTafzili1 { get; set; }

    }

}
