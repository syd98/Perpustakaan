using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class Buku
    {
        [Key]
        public int IdBuku{ get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Judul Buku")]
        public string Judul { get; set; }
        public int Tahun { get; set; }

        [ForeignKey("Penerbit")]
        public int IdPenerbit { get; set; }
        public Penerbit Penerbit { get; set; }

        [ForeignKey("Penulis")]
        public int IdPenulis { get; set; }    
        public Penulis Penulis{ get; set; }

    }
}
