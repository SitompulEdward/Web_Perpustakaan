using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Web_Perpustakaan.Data;
using Web_Perpustakaan.Models;

namespace Web_Perpustakaan.Controllers
{
    public class BukuController : Controller
    {
        
        private readonly AppDbContext _context;
        public BukuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

       
        
        [HttpPost]
        public async Task<IActionResult> Create(Buku parameter)
        {
            var id = "BK-";
            int a = 001;
            parameter.Id = id + a;

            if (ModelState.IsValid)
            {
                // proses masukan ke database

                _context.Add(parameter);
                await _context.SaveChangesAsync();

                //string contentRootPath = _hostingEnvironment.ContentRootPath;
                //string docPath = Path.Combine(_hostingEnvironment.ContentRootPath, "~/images");

                a++;

                return Redirect("Index"); // menerima inputan
            }

            return View(parameter);
        }

        public IActionResult Index()
        {
            var data = _context.Tb_Buku.ToList();
            return View(data);
        }
    }
}
    


