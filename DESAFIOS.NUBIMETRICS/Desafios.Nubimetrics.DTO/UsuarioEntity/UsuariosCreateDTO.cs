using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.UsuarioEntity
{
    public class UsuariosCreateDTO
    {
       
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Password { get; set; }
        public bool EstaActivo { get; set; } = true;

    }
}
