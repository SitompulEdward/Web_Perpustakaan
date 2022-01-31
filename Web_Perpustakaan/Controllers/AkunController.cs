using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web_Perpustakaan.Data;
using Web_Perpustakaan.Models;

namespace Web_Perpustakaan.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;
        public AkunController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {
            var cariUsername = _context.Tb_User.Where(x => x.Username == datanya.Username).FirstOrDefault();

            if (cariUsername != null)
            {
                var cekPassword = _context.Tb_User.Where(x => x.Username == datanya.Username
                                                         && x.Password == datanya.Password)
                                                         //.Include(x2 => x2.Roles)
                                                         .FirstOrDefault();

                // proses tampungan data

                if (cekPassword != null)
                {
                    //var daftar = new List<Claim>
                    //{
                    //    new Claim ("Username", cariUsername.Username),
                    //    new Claim("Role", cariUsername.Roles.Id)
                    //};

                    //// proses daftar Auth

                    //await HttpContext.SignInAsync(
                    //    new ClaimsPrincipal(
                    //        new ClaimsIdentity(daftar, "Cookie", "Username", "Role")
                    //    )
                    //);

                    //if (cariUsername.Roles.Id == "1")
                    //{
                    //    return RedirectToAction(controllerName: "Home", actionName: "Index");
                    //}

                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }
                ViewBag.pesan = "Password Salah !";
                return View(datanya);
            }

            ViewBag.pesan = "Username Salah !";
            return View(datanya);
        }
    }
}
