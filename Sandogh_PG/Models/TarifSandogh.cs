using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
   public class TarifSandogh
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int SandoghSerial { get; set; }
        [Required, MaxLength(150)]
        public string NameSandogh { get; set; }
        [MaxLength(150)]
        public string NameModir { get; set; }
        [MaxLength(400)]
        public string Adress { get; set; }
        [MaxLength(23)]
        public string Tell { get; set; }
        [MaxLength(23)]
        public string Mobile { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TarikhEjad { get; set; }
        public byte[]  Pictuer { get; set; }
        public byte[]  PicBackground { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TarikhRegister { get; set; } // در ورژن بعدی حذف شود
        //[Required]
        public bool AppActived { get; set; } // در ورژن بعدی حذف شود
        //[Required]
        public bool IsGaranti { get; set; }// در ورژن بعدی حذف شود
        [MaxLength(20)]
        public string ShomareNoskheBarname { get; set; } // در ورژن بعدی حذف شود
        public string MadarBoardCode { get; set; }// در ورژن بعدی حذف شود
        [Column(TypeName = "Date")]
        public DateTime TarikhEtmamGaranti { get; set; }// در ورژن بعدی حذف شود


        //[MaxLength(50)]
        //public string StringEtmamGaranti { get; set; }
        //public string DeviceID { get; set; }
        //public string LNDeviceID { get; set; }
        //public string DataBaseName { get; set; }
        //public string LNDataBaseName { get; set; }
        //public string VersionType { get; set; }
        //public string VersionNumber { get; set; }


        public virtual Tanzimat Tanzimat1 { get; set; }
        public virtual ICollection<SalMali> SalMalis { get; set; }
        public virtual ICollection<CodeMoin> CodeMoins { get; set; }
        public virtual ICollection<GroupTafzili> GroupTafzilis { get; set; }
        public virtual ICollection<AllHesabTafzili> AllHesabTafzilis { get; set; }
        public virtual ICollection<MasolinSandogh> MasolinSandoghs { get; set; }

    }
}
