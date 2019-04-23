﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class CodingDaramadVHazine
    {
        public int Id { get; set; }
        [Required]
        public int SandoghId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public int GroupIndex { get; set; }
        [Required, MaxLength(10)]
        public string GroupName { get; set; }
        [MaxLength(100)]
        public string HesabName { get; set; }
        [Required]
        public int SalMaliId { get; set; }
        public virtual TarifSandogh TarifSandogh1 { get; set; }
    }
}
