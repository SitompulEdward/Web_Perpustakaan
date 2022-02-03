using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Perpustakaan.Models
{
    public class Pengembalian 
    {
        [key]
        public string Id { get; set; }
        public string Nama_Lengkap { get; set; }
        public string Tgl_Kembali_Seharusnya { get; set; }
        public string Tgl_Kembali { get; set; }
        public string Peminjaman { get; set; }

        [ForeignKey("Peminjaman")]
        public Peminjaman FkPeminjaman { get; set; }
    }
}
