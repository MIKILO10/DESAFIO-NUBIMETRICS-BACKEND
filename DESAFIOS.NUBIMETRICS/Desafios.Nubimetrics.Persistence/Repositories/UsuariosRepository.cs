using Desafios.Nubimetrics.Domain.Entities;
using Desafios.Nubimetrics.Persistence.Context;
using Desafios.Nubimetrics.Persistence.Generics;
using Desafios.Nubimetrics.Persistence.Repositories.Interfaces;
using Serilog;


namespace Desafios.Nubimetrics.Persistence.Repositories
{
    public class UsuariosRepository : GenericRepository<Usuarios>, IUsuariosRepository
    {
        private readonly NubimetricsDbContext _nubimetricsDbContext;
        private readonly ILogger _logger;
        public UsuariosRepository(NubimetricsDbContext nubimetricsDbContext, ILogger logger) : base(nubimetricsDbContext, logger)
        {
            _nubimetricsDbContext= nubimetricsDbContext;
            _logger = logger;
        }

       
    }
}
