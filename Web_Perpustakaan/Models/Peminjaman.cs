using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Perpustakaan.Models
{
    public class Peminjaman
    {
        [key]
        public string Id { get; set; }
        public string Nama_Lengkap { get; set; }
        public string No_Handphone { get; set; }
        public string Alamat { get; set; }
        public DateTime Tgl_Peminjaman { get; set; }
        public DateTime Tgl_Pengembalian { get; set; }
        public string User { get; set; }
        public string BukuId { get; set; }

        [ForeignKey("User")]
        public User FkUser { get; set; }

        [ForeignKey("BukuId")]
        public Buku FkBuku { get; set; }
        
    }
}
