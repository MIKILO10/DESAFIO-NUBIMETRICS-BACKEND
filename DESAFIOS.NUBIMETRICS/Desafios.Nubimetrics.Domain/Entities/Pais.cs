using Desafios.Nubimetrics.Domain.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Domain.Entities
{
    public class Pais : GenericEntity
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Locale { get; set; }
        public string? CurrencyId { get; set; }
    }
}
