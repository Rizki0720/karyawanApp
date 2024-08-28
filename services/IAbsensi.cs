using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using karyawanApp.Models;

namespace karyawanApp.services
{
    public interface IAbsensi
    {
        Task<List<AbsensiKaryawan>> GetAbsensi();
        Task<AbsensiKaryawan> AddAbsensi(AbsensiKaryawan payload);
        Task<AbsensiKaryawan> AbsensiByKodeKaryawan(string kodeKaryawan);
        Task Delete(string id);
        Task<AbsensiKaryawan> GetById(string id);
    }
}