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
    public class NubimetricsUnitOfWork : GenericUnitOfWork<NubimetricsDbContext>, IDisposable
    {
        private readonly ILogger _logger;

        private PaisRepository? _paisRepository;


        public NubimetricsUnitOfWork(NubimetricsDbContext context, ILoggerFactory loggerFactory) : base(context)
        {
            _logger = loggerFactory.CreateLogger<NubimetricsUnitOfWork>();
        }

        public IPaisRepository  paisRepository => _paisRepository   = _paisRepository ?? new PaisRepository(_context, _logger);


    }
}
