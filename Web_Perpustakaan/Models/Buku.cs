using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Perpustakaan.Models
{
    public class Buku
    {
        [key]
        public string Id { get; set; }        
        public string Judul_Buku { get; set; }
        public string Pengarang { get; set; }
        public string Penerbit { get; set; }
        public string Tahun_Terbit { get; set; }
        public string Gambar { get; set; }
    }
}
