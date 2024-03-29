﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class CheckTazmin
    {
        public int Id { get; set; }
        [Required]
        public int SeryalDaryaft { get; set; }
        [Required,Column(TypeName = "Date")]
        public DateTime TarikhDaryaft { get; set; }
        [Required]
        public int VamGerandeId { get; set; }
        [Required, MaxLength(100)]
        public string VamGerandeName { get; set; }
        [Required]
        public int NoeSanadId { get; set; }
        [Required,MaxLength(10)]
        public string NoeSanad { get; set; }
        [Required, MaxLength(15)]
        public string ShCheck { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhCheck { get; set; }
        public decimal Mablagh { get; set; }
        [MaxLength(40)]
        public string ShomareHesab { get; set; }
        [MaxLength(40)]
        public string NameBank { get; set; }
        [MaxLength(40)]
        public string SahebCheck { get; set; }
        [MaxLength(200)]
        public string SharhDaryaftCheck { get; set; }
        [Required,MaxLength(40)]
        public string VaziyatCheck { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhOdatCheck { get; set; }
        [MaxLength(200)]
        public string SharhOdatCheck { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public bool IsInSandogh { get; set; }
        //public bool VaziatAtf { get; set; }
        //public int AtfVamId { get; set; }
        public virtual AllHesabTafzili AllHesabTafzili1 { get; set; }
        public virtual SalMali SalMali1 { get; set; }
        public virtual ICollection<R_VamPardakhti_B_CheckTazmin> R_VamPardakhti_B_CheckTazmins { get; set; }

    }
}
