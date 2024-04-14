using Desafios.Nubimetrics.Domain.Entities;
using Desafios.Nubimetrics.Persistence.Context;
using Desafios.Nubimetrics.Persistence.Generics;
using Desafios.Nubimetrics.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Desafios.Nubimetrics.Persistence.Repositories
{
    public class UsuariosRepository : GenericRepository<Usuarios>, IUsuariosRepository
    {
        private readonly NubimetricsDbContext _nubimetricsDbContext;
        public UsuariosRepository(NubimetricsDbContext nubimetricsDbContext, ILogger logger) : base(nubimetricsDbContext, logger)
        {
            _nubimetricsDbContext= nubimetricsDbContext;

        }

       
    }
}
