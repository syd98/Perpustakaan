using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class BukuController : Controller
    {
        private readonly AppDBContext _context;
        readonly Models.DataSets dbds = new Models.DataSets();

        public BukuController(AppDBContext context)
        {
            _context = context;
        }

        // GET: BukuController
        // GET: Buku
        public IActionResult Index()
        {

            var dataJoin = (from a in _context.Bukus
                            join b in _context.Penerbits
                            on a.IdPenerbit equals b.IdPenerbit
                            join c in _context.Penuliss
                            on a.IdPenulis equals c.IdPenulis
                            select new IBuku
                            {
                                Buku = a,
                                Penerbit = b,
                                Penulis = c
                            }).ToList();
            //return View(await _context.Bukus.ToListAsync());
            return View(dataJoin);
        }


        // GET: Buku/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                IBuku IBuku = new IBuku();
                IBuku.Buku = new Buku();
                List<SelectListItem> penerbits = _context.Penerbits
                    .OrderBy(n => n.Nama)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.IdPenerbit.ToString(),
                            Text = n.Nama
                        }).ToList();
                IBuku.Penerbits = penerbits;

                List<SelectListItem> penuliss = _context.Penuliss
                    .OrderBy(n => n.Nama)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.IdPenulis.ToString(),
                            Text = n.Nama
                        }).ToList();
                IBuku.Penuliss = penuliss;

                return View(IBuku);
            }
            else
            {
                IBuku IBuku = new IBuku();
                IBuku.Buku = new Buku();
                IBuku.Buku = _context.Bukus.Find(id);
                List<SelectListItem> penerbits = _context.Penerbits
                    .OrderBy(n => n.Nama)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.IdPenerbit.ToString(),
                            Text = n.Nama
                        }).ToList();
                IBuku.Penerbits = penerbits;

                List<SelectListItem> penuliss = _context.Penuliss
                    .OrderBy(n => n.Nama)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.IdPenulis.ToString(),
                            Text = n.Nama
                        }).ToList();
                IBuku.Penuliss = penuliss;
                return View(IBuku);
            }
                
        }


        // POST: Buku/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdBuku,Judul,Tahun,IdPenerbit,IdPenulis")] Buku buku)
        {
            if (ModelState.IsValid)
            {
                if (buku.IdBuku == 0)
                    _context.Add(buku);
                else
                    _context.Update(buku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buku);
        }


        // GET: Buku/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var buku = await _context.Bukus.FindAsync(id);
            _context.Bukus.Remove(buku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
