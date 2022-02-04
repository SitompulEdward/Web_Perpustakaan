using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Perpustakaan.Models
{
    public class PeminjamanForm
    {
        public string Id { get; set; }
        [Required]
        public string Nama_Lengkap { get; set; }
        [Required]
        public string No_Handphone { get; set; }
        [Required]
        public string Alamat { get; set; }
        [Required]
        public DateTime Tgl_Peminjaman { get; set; }
        [Required]
        public DateTime Tgl_Pengembalian { get; set; }
        
        [Required]
        public string BukuId { get; set; }
    }
}
