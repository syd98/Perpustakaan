using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class PenulisController : Controller
    {
        private readonly AppDBContext _context;

        public PenulisController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Penulis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Penuliss.ToListAsync());
        }


        // GET: Penulis/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Penulis());
            else
                return View(_context.Penuliss.Find(id));
        }

        // POST: Penulis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdPenulis,Nama,Gender,NoTelp")] Penulis penulis)
        {
            if (ModelState.IsValid)
            {
                if (penulis.IdPenulis == 0)
                    _context.Add(penulis);
                else
                    _context.Update(penulis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penulis);
        }


        // GET: Penulis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var penulis = await _context.Penuliss.FindAsync(id);
            _context.Penuliss.Remove(penulis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
