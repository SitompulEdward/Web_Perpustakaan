using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Perpustakaan.Data;
using Web_Perpustakaan.Models;

namespace Web_Perpustakaan.Controllers
{
    [Authorize]
    public class PengembalianController : Controller
    {
        private readonly AppDbContext _context;
        public PengembalianController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Tb_Pengembalian.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PengembalianForm data)
        {
            string[] Id = _context.Tb_Pengembalian.Select(x => x.Id).ToArray();   

            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-")[1]);
                data.Id = "PG-" + (temp + 1);
            }

            if (data.Id == null)
            {
                data.Id = "PG-1";
            }

            var TglPinjam = _context.Tb_Peminjaman.Where(x => x.Id == data.PeminjamanId).Select(x => x.Tgl_Peminjaman).FirstOrDefault();

            data.Tgl_Kembali_Seharusnya = TglPinjam;

            var get = new Pengembalian
            {
                Id = data.Id,
                Tgl_Kembali_Seharusnya = data.Tgl_Kembali_Seharusnya,
                Nama_Lengkap = data.Nama_Lengkap,
                Tgl_Kembali = data.Tgl_Kembali,
                PeminjamanId = data.PeminjamanId
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
