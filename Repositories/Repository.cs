using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace karyawanApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> FindAllAsync()
        {
            var data = await _context.Set<TEntity>().ToListAsync();

            return data;
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            var data = await _context.Set<TEntity>().FindAsync(id);
            return data;
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            var entry = await _context.Set<TEntity>().AddAsync(entity);
            return entry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var EmployeeUpdate = Attach(entity);
            _context.Set<TEntity>().Update(EmployeeUpdate);
            return EmployeeUpdate;
        }

        public TEntity Attach(TEntity entity)
        {
            var data = _context.Set<TEntity>().Attach(entity);
            return data.Entity;
        }

        public async Task<TEntity> FindByKodeKaryawan(string? kodeKaryawan)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => EF.Property<string>(e, "KodeKaryawan") == kodeKaryawan);
        }

    }
}