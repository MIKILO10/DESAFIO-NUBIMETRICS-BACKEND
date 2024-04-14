using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.UsuarioEntity
{
    public class UsuariosDeleteDTO
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id { get; set; }
    }
}
