using Desafios.Nubimetrics.Persistence.Context;
using Desafios.Nubimetrics.Persistence.Generics;
using Desafios.Nubimetrics.Persistence.Repositories;
using Desafios.Nubimetrics.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Persistence.UnitOfWork
{
    public class NubimetricsUnitOfWork 
    {
        private readonly ILogger _logger;
        private readonly NubimetricsDbContext _context;

        private UsuariosRepository? _usuariosRepository;


        public NubimetricsUnitOfWork(NubimetricsDbContext context, ILoggerFactory loggerFactory) 
        {
            _logger = loggerFactory.CreateLogger<NubimetricsUnitOfWork>();
            _context= context;
        }

        public IUsuariosRepository  usuariosRepository => _usuariosRepository = _usuariosRepository ?? new UsuariosRepository(_context, _logger);


    }
}
