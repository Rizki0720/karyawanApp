

namespace karyawanApp.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> SaveAsync(TEntity entity);
        Task<List<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(Guid id);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Attach(TEntity entity);
        Task<TEntity> FindByKodeKaryawan(string kodeKaryawan);


    }


}