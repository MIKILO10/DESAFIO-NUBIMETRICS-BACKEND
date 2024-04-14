using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.Utils
{
    public class Paged
    {
        public int EntityCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public Paged()
        {
            PageNumber = 1;
            PageSize = 10;
        }

    }
}
