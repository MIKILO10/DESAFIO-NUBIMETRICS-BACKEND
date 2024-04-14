using Desafios.Nubimetrics.DTO.BusquedaEntity.SellerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.BusquedaEntity.ResultsEntity
{
    public class ResultsGetDTO
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Site_Id { get; set; }
        public double? Price { get; set; }
        public string? Permalink { get; set; }
        public SellerGetDTO? Seller { get; set; }

    }

}
