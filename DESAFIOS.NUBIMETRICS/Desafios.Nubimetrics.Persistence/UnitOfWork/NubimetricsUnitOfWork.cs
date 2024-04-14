using Desafios.Nubimetrics.Persistence.Context;
using Desafios.Nubimetrics.Persistence.Repositories;
using Desafios.Nubimetrics.Persistence.Repositories.Interfaces;
using Serilog;

namespace Desafios.Nubimetrics.Persistence.UnitOfWork
{
    public class NubimetricsUnitOfWork 
    {
        private readonly ILogger _logger;
        private readonly NubimetricsDbContext _context;

        private UsuariosRepository? _usuariosRepository;


        public NubimetricsUnitOfWork(NubimetricsDbContext context ) 
        {
            _logger = Log.ForContext<NubimetricsUnitOfWork>();
            _context= context;
        }

        public IUsuariosRepository  usuariosRepository => _usuariosRepository = _usuariosRepository ?? new UsuariosRepository(_context, _logger);


    }
}
