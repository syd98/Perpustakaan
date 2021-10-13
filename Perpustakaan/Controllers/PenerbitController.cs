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
    public class PenerbitController : Controller
    {
        private readonly AppDBContext _context;

        public PenerbitController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Penerbit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Penerbits.ToListAsync());
        }


        // GET: Penerbit/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Penerbit());
            else
                return View(_context.Penerbits.Find(id));
        }

        // POST: Penerbit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdPenerbit,Nama,Alamat,NoTelp")] Penerbit penerbit)
        {
            if (ModelState.IsValid)
            {
                if (penerbit.IdPenerbit == 0)
                    _context.Add(penerbit);
                else
                    _context.Update(penerbit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penerbit);
        }


        // GET: Penerbit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var penerbit = await _context.Penerbits.FindAsync(id);
            _context.Penerbits.Remove(penerbit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
