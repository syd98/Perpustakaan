using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class Penulis
    {
        [Key]
        public int IdPenulis { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Nama Penulis")]
        public string Nama { get; set; }

        [DisplayName("Jenis Kelamin Penulis")]
        public string Gender { get; set; }

        public string NoTelp { get; set; }
    }
}
