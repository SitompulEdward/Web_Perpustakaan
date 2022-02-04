using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Perpustakaan.Data;
using Web_Perpustakaan.Models;

namespace Web_Perpustakaan.Controllers
{
    public class PeminjamanController : Controller
    {
        private readonly AppDbContext _context;
        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Tb_Peminjaman.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(PeminjamanForm data)
        {
            string[] Id = _context.Tb_Peminjaman.Select(x => x.Id).ToArray();

            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-")[1]);
                data.Id = "PJ-" + (temp + 1);
            }

            if (data.Id == null)
            {
                data.Id = "PJ-1";
            }

            data.Tgl_Peminjaman = DateTime.Now;

            var get = new Peminjaman
            {
                Id = data.Id,
                Nama_Lengkap = data.Nama_Lengkap,
                No_Handphone = data.No_Handphone,
                Alamat = data.Alamat,
                Tgl_Peminjaman = data.Tgl_Peminjaman,
                Tgl_Pengembalian = data.Tgl_Pengembalian,
                BukuId = data.BukuId
            };

            if (ModelState.IsValid)
            {
                _context.Add(get);
                await _context.SaveChangesAsync();

                return Redirect("Index");
            }

            return View(data);

        }
    }
}
