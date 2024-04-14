using Desafios.Nubimetrics.Domain.Entities.Generics;
using Desafios.Nubimetrics.DTO.Utils;

namespace Desafios.Nubimetrics.Persistence.Generics.Interfaces
{
    public interface IGenericRepository<T> where T : GenericEntity
    {
        Task<Result<T>> Create(T entity);
        Task<Result<T>> Update(T entity);
        Task<Result<T>> Delete(T entity);
      
    }
}
