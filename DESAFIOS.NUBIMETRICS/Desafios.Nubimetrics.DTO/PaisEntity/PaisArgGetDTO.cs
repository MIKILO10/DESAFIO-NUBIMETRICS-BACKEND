using Desafios.Nubimetrics.DTO.PaisEntity.LocationEntity;
using Desafios.Nubimetrics.DTO.PaisEntity.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.PaisEntity
{
    public class PaisArgGetDTO : PaisGetDTO
    {
        public string? Decimal_Separator { get; set; }
        public string? Thousands_Separator { get; set; }
        public string? Time_Zone { get; set; }
        public LocationGetDTO? Geo_Information { get; set; }
        public List<StateGetDTO>? States { get; set; }

    }
}
