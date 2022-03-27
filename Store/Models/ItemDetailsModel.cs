using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ItemDetailsModel
    {
        public IEnumerable<TbItem> lstRelatedItems { get; set; }
        public TbItem Item { get; set; }
    }
}
