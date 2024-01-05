using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
    public class TedadZamenin
    {
        public int Id { get; set; }
        [Required]
        public decimal Mablagh { get; set; }
        [Required]
        public int TedadZamen { get; set; }
        //public string SandoghName { get; set; }
        [Required]
        public int AnvaeVamId { get; set; }
        public virtual AnvaeVam AnvaeVam1 { get; set; }


    }
}
