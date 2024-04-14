using Desafios.Nubimetrics.DTO.BusquedaEntity.PagingEntity;
using Desafios.Nubimetrics.DTO.BusquedaEntity.ResultsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.BusquedaEntity
{
    public class BusquedaGetDTO
    {
        public string? Site_Id { get; set; }
        public string? Country_Default_Time_Zone { get; set; }
        public string? Query { get; set; }
        public PagingGetDTO? Paging { get; set; }

        public List<ResultsGetDTO>? Results { get; set; }

    }
}
