using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using karyawanApp.Models;
using Microsoft.EntityFrameworkCore;

namespace karyawanApp.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        public DbSet<AbsensiKaryawan> AbsensiKaryawan { get; set; }

        protected AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}