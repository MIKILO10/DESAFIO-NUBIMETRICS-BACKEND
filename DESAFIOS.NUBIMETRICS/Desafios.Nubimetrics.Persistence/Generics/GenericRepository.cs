﻿using Desafios.Nubimetrics.DTO.Utils;
using Desafios.Nubimetrics.Persistence.Generics.Interfaces;
using Microsoft.EntityFrameworkCore;
using Desafios.Nubimetrics.Domain.Entities.Generics;
using Serilog;

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

                _logger.Information("{Repo} Insert function succeeded", typeof(T).Name);

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "{Repo} Insert function error");

                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<Result<T>> Update(T entity, int id)
        {
            try
            {
                var exist = await dbSet.FindAsync(id);

                if (exist == null)
                    return Result<T>.Failure($"No se encontró el registro con el id {id}");

                entity.FechaModificacion = DateTime.Now;

                var dbEntry = _context.Entry(entity);
                dbEntry.State = EntityState.Modified;

                dbEntry.Property(x => x.FechaAlta).IsModified = false;

                await _context.SaveChangesAsync();

                _logger.Information("{Repo} Update function succeeded", typeof(T).Name);

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "{Repo} Update function error");
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<Result<T>> Delete(int id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);

                if (entity == null)
                {
                    _logger.Warning("{Repo} Delete function failed: No se encontró el registro con el id {Id}", typeof(T).Name, id);
                    return Result<T>.Failure($"No se encontró el registro con el id {id}");
                }

                entity.EstaActivo = false;
                entity.FechaEliminacion = DateTime.Now;

                var dbEntry = _context.Entry(entity);
                dbEntry.State = EntityState.Unchanged;

                dbEntry.Property(x => x.EstaActivo).IsModified = true;
                dbEntry.Property(x => x.FechaEliminacion).IsModified = true;

                await _context.SaveChangesAsync();

                _logger.Information("{Repo} Delete function succeeded", typeof(T).Name);

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "{Repo} Delete function error");
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<Result<T>> GetById(int id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);

                if (entity == null)
                {
                    _logger.Warning("{Repo} GetById function failed: No se encontró el registro con el id {Id}", typeof(T).Name, id);
                    return Result<T>.Failure($"No se encontró el registro con el id {id}");
                }

                _logger.Information("{Repo} GetById function succeeded", typeof(T).Name);

                return Result<T>.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "{Repo} GetById function error");
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<Result<List<T>>> GetAll()
        {
            try
            {
                var entities = await dbSet.ToListAsync();
                _logger.Information("{Repo} GetAll function succeeded", typeof(T).Name);
                return Result<List<T>>.Success(entities);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "{Repo} GetAll function error");
                return Result<List<T>>.Failure(ex.Message);
            }
        }


    }
}
