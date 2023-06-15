using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Dtos
{
    public class PagedResult<T>
    {
        public int TotalRecord { set; get; }
        public List<T>? Items { set; get; }
    }
}
