using Desafios.Nubimetrics.DTO.Utils;
using Desafios.Nubimetrics.Persistence.Generics.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Desafios.Nubimetrics.Domain.Entities.Generics;

namespace Desafios.Nubimetrics.Persistence.Generics
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : GenericEntity
    {
        protected DbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DbContext context, ILogger logger)
        {
            this._context = context;
            this.dbSet = context.Set<T>();
            this._logger = logger;
        }


   
        public virtual async Task<Result<T>> Create(T entity)
        {
            try
            {
                entity.FechaAlta = DateTime.Now;

                await dbSet.AddAsync(entity);

                await _context.SaveChangesAsync();

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Insert function error", "");
                throw new Exception(ex.Message);

            }
        }

        public virtual async Task<Result<T>> Update(T entity)
        {
            try
            {
                entity.FechaModificacion = DateTime.Now;

                var dbEntry = _context.Entry(entity);
                dbEntry.State = EntityState.Modified;

                dbEntry.Property(x => x.FechaAlta).IsModified = false;

                await _context.SaveChangesAsync();

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", "");
                throw new Exception(ex.Message);
            }
        }

       
        public virtual async Task<Result<T>> Delete(T entity)
        {
            try
            {
                entity.EstaActivo = false;
                entity.FechaEliminacion = DateTime.Now;

                var dbEntry = _context.Entry(entity);
                dbEntry.State = EntityState.Unchanged;

                dbEntry.Property(x => x.EstaActivo).IsModified = true;
                dbEntry.Property(x => x.FechaEliminacion).IsModified = true;

                await _context.SaveChangesAsync();

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", "");
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<Result<T>> GetById(int id)
        {
            
            try
            {
                var entity = await dbSet.FindAsync( id);

                if (entity == null)
                {
                    return Result<T>.Failure($"No se encontro el registro con el id {id}");
                }

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById function error", "");
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<Result<List<T>>> GetAll()
        {
            try
            {
                var entities = await dbSet.ToListAsync();
                return Result<List<T>>.Success(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll function error", "");
                return Result<List<T>>.Failure(ex.Message);
            }
        }
    }

}
