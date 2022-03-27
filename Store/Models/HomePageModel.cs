using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace Store.Models
{
    public class HomePageModel
    {
        public IEnumerable<TbItem> lstItems { get; set; }
        public IEnumerable<TbItem> lstNewItems { get; set; }
        public IEnumerable<TbItem> lstPopularItems { get; set; }
        public IEnumerable<TbItemDiscount> lstItemsDiscount { get; set; }
        public IEnumerable<TbSlider> lstSliders { get; set; }
        public IEnumerable<TbMobileLogo> lstMobileLogos { get; set; }      
    }
}
