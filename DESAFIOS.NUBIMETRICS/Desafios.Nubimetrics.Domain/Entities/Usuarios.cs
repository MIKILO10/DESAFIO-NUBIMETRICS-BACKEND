using Desafios.Nubimetrics.Domain.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Domain.Entities
{
    public class Usuarios:GenericEntity
    {
        public int IdUsuario
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
