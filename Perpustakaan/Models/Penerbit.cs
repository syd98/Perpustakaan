using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class Penerbit
    {
        [Key]
        public int IdPenerbit { get; set; }
        
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Nama Penerbit")]
        public string Nama { get; set; }
        
        [DisplayName("Alamat Penerbit")]
        public string Alamat { get; set; }
        
        public string NoTelp { get; set; }
    }
}
