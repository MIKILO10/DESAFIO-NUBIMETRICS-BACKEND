using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Persistence.Generics.Interfaces
{
    public interface IGenericUnitOfWork<T> where T : DbContext
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        void Dispose();
    }
}
