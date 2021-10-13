using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class Peminjaman
    {
        [Key]
        public int IdPeminjaman { get; set; }
        [ForeignKey("Buku")]
        public int IdBuku { get; set; }
        public virtual Buku Buku { get; set; }
        public string NamaPeminjam { get; set; }
        //public DateTime TglPeminjaman { get; set; }
        public int IsPengembalian { get; set;}


        //public virtual List<DetailPenjualan> DetailPenjualans { get; set; } = new List<DetailPenjualan>();
    }
}
