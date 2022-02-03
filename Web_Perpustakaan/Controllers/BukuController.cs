using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Web_Perpustakaan.Data;
using Web_Perpustakaan.Models;
using Microsoft.AspNetCore.Hosting;

namespace Web_Perpustakaan.Controllers
{
    public class BukuController : Controller
    {
        
        private readonly AppDbContext _context;
        
        IWebHostEnvironment _env;
        public BukuController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Create()
        {
            return View();
        }

       
        
        [HttpPost]
        public async Task<IActionResult> Create(Buku parameter, IFormFile Gambar)
        {
            string[] Id = _context.Tb_Buku.Select(x => x.Id).ToArray();
           
            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-")[1]);
                parameter.Id = "BK-" + (temp + 1);
            }
            if (ModelState.IsValid)
            {
                parameter.Gambar = Gambar.FileName;

                string FilePath = Path.Combine(_env.WebRootPath, "UploadImg");

                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                string FileName = Gambar.FileName;

                string FullPath = Path.Combine(FilePath, FileName);

                using(var stream  = new FileStream(FullPath, FileMode.Create))
                {
                    await Gambar.CopyToAsync(stream);
                }
                // proses masukan ke database

                _context.Add(parameter);
                await _context.SaveChangesAsync();



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
    


