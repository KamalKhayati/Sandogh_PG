using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class AllowedDevise
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsGaranti { get; set; }
        [Column(TypeName = "Date")]
        public DateTime GarantiEndData { get; set; }
        //[MaxLength(500)]
        public string LNGarantiEndData { get; set; }
        //[MaxLength(500)]
        public string DeviceID { get; set; }
        //[MaxLength(500)]
        public string LNDeviceID { get; set; }
        //[MaxLength(500)]
        public string DataBaseName { get; set; }
        //[MaxLength(500)]
        public string LNDataBaseName { get; set; }
        //[MaxLength(500)]
        public string VersionType { get; set; }
       // [MaxLength(500)]
        public string LNVersionType { get; set; }
       // [MaxLength(500)]
        public string VersionNumber { get; set; }
        //[MaxLength(500)]
        public string LNVersionNumber { get; set; }
        [Column(TypeName = "Date")]
        public DateTime RegisterDate { get; set; }

    }
}
