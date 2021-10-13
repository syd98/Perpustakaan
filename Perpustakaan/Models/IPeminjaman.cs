using Microsoft.AspNetCore.Mvc.Rendering;
using Perpustakaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class IPeminjaman
    {
        public Peminjaman Peminjaman { get; set; }
        public IEnumerable<SelectListItem> Bukus { get; set; }

        public Buku Buku { get; set; }
    }
}
