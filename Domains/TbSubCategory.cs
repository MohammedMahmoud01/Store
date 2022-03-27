using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSubCategory
    {
        public TbSubCategory()
        {
            TbItems = new HashSet<TbItem>();
        }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual ICollection<TbItem> TbItems { get; set; }
    }
}
