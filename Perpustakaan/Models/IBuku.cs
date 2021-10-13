using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class IBuku
    {
        public Buku Buku { get; set; }
        public IEnumerable<SelectListItem> Penerbits { get; set; }
        public IEnumerable<SelectListItem> Penuliss { get; set; }

        public Penerbit Penerbit { get; set; }
        public Penulis Penulis { get; set; }
    }
}
