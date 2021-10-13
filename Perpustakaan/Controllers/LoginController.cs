using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDBContext _context;
        public LoginController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User log)
        {
            var obj = _context.Users.Where(
                      a => a.Username.Equals(log.Username) && a.Password.Equals(log.Password)).FirstOrDefault();
            if(obj != null)
            {
                //return Content("Berhasil Login");
                return Redirect("/Peminjaman/Add");
            }
            else
            {
                //return Content("Tidak Berhasil Login");
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Regis(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regis([Bind("IdUser,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IdUser == 0)
                    _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);

        }
    }
}
