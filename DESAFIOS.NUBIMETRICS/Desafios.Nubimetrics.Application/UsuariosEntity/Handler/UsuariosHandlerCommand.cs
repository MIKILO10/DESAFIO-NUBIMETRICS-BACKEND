using Desafios.Nubimetrics.Application.UsuariosEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.UsuariosEntity.Handler
{
    public partial class UsuariosEventHandler
    {
        private readonly UsuariosService _usuariosService;
        public UsuariosEventHandler(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;

        }
    }
}
