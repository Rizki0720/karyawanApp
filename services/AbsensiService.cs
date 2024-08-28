using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using karyawanApp.Models;
using karyawanApp.Repositories;

namespace karyawanApp.services
{
    public class AbsensiService : IAbsensi
    {
        private readonly IRepository<AbsensiKaryawan> _absensiRepository;
        private readonly IPersistance _persistance;
        private readonly IRepository<Employee> _employeeRepository;

        public AbsensiService(IRepository<AbsensiKaryawan> absensiRepository, IPersistance persistance, IRepository<Employee> employeeRepository)
        {
            _absensiRepository = absensiRepository;
            _persistance = persistance;
            _employeeRepository = employeeRepository;
        }

        public async Task<AbsensiKaryawan> AbsensiByKodeKaryawan(string kodeKaryawan)
        {
            var employee = await _absensiRepository.FindByKodeKaryawan(kodeKaryawan);

            return employee;
        }

        public async Task<AbsensiKaryawan> AddAbsensi(AbsensiKaryawan payload)
        {
            var employee = await _employeeRepository.FindByKodeKaryawan(payload.KodeKaryawan);
            var absensi = await _absensiRepository.SaveAsync(payload);
            if (employee != null)
            {
                employee.Keterangan = "Hadir";
                _employeeRepository.Update(employee);
                await _persistance.SaveChangesAsync();
            }
            await _persistance.SaveChangesAsync();
            return absensi;
        }

        public async Task Delete(string id)
        {
            var Absensi = await GetById(id);
            if (Absensi == null)
            {
                throw new InvalidOperationException("Absensi tidak ditemukan");
            }

            var employee = await _employeeRepository.FindByKodeKaryawan(Absensi.KodeKaryawan);
            _absensiRepository.Delete(Absensi);

            if (employee != null)
            {
                employee.Keterangan = "Tidak Hadir";
                _employeeRepository.Update(employee);
            }

            await _persistance.SaveChangesAsync();
        }

        public async Task<List<AbsensiKaryawan>> GetAbsensi()
        {
            var absensi = await _absensiRepository.FindAllAsync();
            return absensi;
        }

        public Task<AbsensiKaryawan> GetById(string id)
        {
            var absensi = _absensiRepository.FindByIdAsync(Guid.Parse(id));
            return absensi;
        }
    }
}
