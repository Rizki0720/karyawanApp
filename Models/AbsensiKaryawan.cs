using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace karyawanApp.Models
{
    [Table(name: "tbl_absensi_karyawan")]
    public class AbsensiKaryawan
    {
        [Key, Column(name: "id")] public Guid Id { get; set; }
        [Column(name: "kode_karyawan")] public string? KodeKaryawan { get; set; }
        [Column(name: "nama_karyawan")] public string? NamaKaryawan { get; set; }
        [Column(name: "tanggal_masuk")] public DateTime TglMasuk { get; set; }
        [Column(name: "tanggal_keluar")] public DateTime TglKeluar { get; set; }
        [Column(name: "jam_masuk")] public TimeSpan JamMasuk { get; set; }
        [Column(name: "jam_keluar")] public TimeSpan JamKeluar { get; set; }

        public AbsensiKaryawan()
        {
            JamMasuk = DateTime.Now.TimeOfDay;
            JamKeluar = DateTime.Now.TimeOfDay;
        }

    }
}