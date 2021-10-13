using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Penerbit> Penerbits { get; set; }
        public DbSet<Penulis> Penuliss { get; set; }
        public DbSet<Buku> Bukus { get; set; }
        public DbSet<Peminjaman> Peminjamans { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
