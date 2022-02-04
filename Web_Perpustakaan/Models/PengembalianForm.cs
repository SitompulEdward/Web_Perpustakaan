using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Perpustakaan.Models
{
    public class PengembalianForm
    {
        public string Id { get; set; }
        [Required]
        public string Nama_Lengkap { get; set; }
        public DateTime Tgl_Kembali_Seharusnya { get; set; }
        [Required]
        public DateTime Tgl_Kembali { get; set; }
        [Required]
        public string PeminjamanId { get; set; }
    }
}
