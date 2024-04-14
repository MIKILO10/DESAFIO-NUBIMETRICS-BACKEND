using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.PaisEntity
{
    public class PaisGetDTO 
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Locale { get; set; }  
        public string? Currency_Id { get; set; }
    }

}
