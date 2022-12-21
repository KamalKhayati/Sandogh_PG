using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG.Models
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
        public string LNGarantiEndData { get; set; }
        public string DeviceID { get; set; }
        public string LNDeviceID { get; set; }
        public string DataBaseName { get; set; }
        public string LNDataBaseName { get; set; }
        public string VersionType { get; set; }
        public string LNVersionType { get; set; }
        public string VersionNumber { get; set; }
        public string LNVersionNumber { get; set; }
        [Column(TypeName = "Date")]
        public DateTime RegisterDate { get; set; }

    }
}
