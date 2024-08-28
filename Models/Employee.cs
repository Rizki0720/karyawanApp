using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace karyawanApp.Models
{
    [Table(name: "tbl_karyawan")]
    public class Employee
    {
        [Key, Column(name: "id")] public Guid Id { get; set; }
        [Column(name: "kode_karyawan")] public string? KodeKaryawan { get; set; }
        [Column(name: "nama_karyawan")] public string? NamaKaryawan { get; set; }
        [Column(name: "jenis_kelamin")] public string? JenisKelamin { get; set; }
        [Column(name: "level_karyawan")] public string? LevelKaryawan { get; set; }
        [Column(name: "email")] public string? Email { get; set; }
        [Column(name: "alamat")] public string? Alamat { get; set; }
        [Column(name: "no_hp")] public string? Telepon { get; set; }
        [Column(name: "keterangan")] public string? Keterangan { get; set; }

        //  public ICollection<AbsensiKaryawan>? AbsensiKaryawans { get; set; }
    }
}