using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.CurrenciesEntity
{
    public class CurrenciesGetDTO
    {
        [Name("Id")]
        public string? Id { get; set; }

        [Name("Symbol")]
        public string? Symbol { get; set; }

        [Name("Description")]
        public string? Description { get; set; }

        [Name("Decimal_Places")]
        public int? Decimal_Places { get; set; }

        [Name("TodoDolar")]
        public TodoDolarGetDTO? TodoDolar { get; set; }
    }

}
