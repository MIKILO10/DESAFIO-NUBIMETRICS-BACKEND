using Desafios.Nubimetrics.Persistence.Generics.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Persistence.Generics
{
    public abstract class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : DbContext
    {
        protected readonly T _context;

        public GenericUnitOfWork(T context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (_context.Database.CurrentTransaction == null)
            {
                await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }

}
