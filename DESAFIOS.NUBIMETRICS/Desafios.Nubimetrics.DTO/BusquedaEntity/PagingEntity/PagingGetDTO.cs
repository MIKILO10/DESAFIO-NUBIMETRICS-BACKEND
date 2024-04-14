using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.BusquedaEntity.PagingEntity
{
    public class PagingGetDTO
    {
        public int? Total { get; set; }
        public int? Primary_Results { get; set; }
        public int? Offset { get; set; }
        public int? Limit { get; set; }
    }
}
