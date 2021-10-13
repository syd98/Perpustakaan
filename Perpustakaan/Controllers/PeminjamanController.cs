using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Perpustakaan.Models;
using Microsoft.EntityFrameworkCore;

namespace Perpustakaan.Controllers
{
    public class PeminjamanController : Controller
    {
        private readonly AppDBContext _context;

        public PeminjamanController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dataJoin = (from a in _context.Peminjamans
                            join b in _context.Bukus 
                            on a.IdBuku equals b.IdBuku
                            where a.IsPengembalian == 0
                            select new IPeminjaman
                            {
                                Peminjaman=a,
                                Buku=b
                            }).ToList();

            //return View(_context.Peminjamans.Where(a => a.IsPengembalian == 0).ToList());
            return View(dataJoin);
        }
        public IActionResult Add()
        {

            IPeminjaman IPeminjaman = new IPeminjaman();
            IPeminjaman.Peminjaman = new Peminjaman();
            List<SelectListItem> bukus = _context.Bukus
                .OrderBy(n => n.Judul)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.IdBuku.ToString(),
                        Text = n.Judul
                    }).ToList();
            IPeminjaman.Bukus = bukus;
            return View(IPeminjaman);

        }

        // POST: Buku/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("IdPeminjaman,NamaPeminjam,IsPengembalian,IdBuku")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peminjaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peminjaman);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var dataJoin = (from a in _context.Peminjamans
            //                join b in _context.Bukus
            //                on a.IdBuku equals b.IdBuku
            //                where a.IdPeminjaman == id
            //                select new IPeminjaman
            //                {
            //                    Peminjaman = a,
            //                    Buku = b
            //                });
            var detail = await _context.Peminjamans.FirstOrDefaultAsync(m => m.IdPeminjaman == id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }
        public async Task<IActionResult> Kembali([Bind("IdPeminjaman,NamaPeminjam,IsPengembalian,IdBuku")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Update(peminjaman);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Pengembalian));
        }

        public IActionResult Pengembalian()
        {

            var dataJoin = (from a in _context.Peminjamans
                            join b in _context.Bukus
                            on a.IdBuku equals b.IdBuku
                            where a.IsPengembalian == 1
                            select new IPeminjaman
                            {
                                Peminjaman = a,
                                Buku = b
                            }).ToList();

            //return View(_context.Peminjamans.Where(a => a.IsPengembalian == 1).ToList());
            return View(dataJoin);
        }

        // GET: Buku/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var peminjaman = await _context.Peminjamans.FindAsync(id);
            _context.Peminjamans.Remove(peminjaman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
