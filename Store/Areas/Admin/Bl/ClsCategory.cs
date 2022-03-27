using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models;
using Domains;
namespace Store.Areas.Admin.Bl
{
    public interface IClsCategory
    {
        List<TbCategory> GetCategories();
        TbCategory GetById(int id);
        bool Add(TbCategory cat);
        bool Edit(TbCategory cat);
        bool Delete(int catId);
    }
    public class ClsCategory : IClsCategory
    {
        StoreContext ctx;
        public ClsCategory(StoreContext context)
        {
            ctx = context;
        }
        public bool Add(TbCategory cat)
        {
            try
            {
                ctx.Add<TbCategory>(cat);

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int catId)
        {
            try
            {
                TbCategory cat = ctx.TbCategories.FirstOrDefault(x => x.CategoryId == catId);

                ctx.Remove<TbCategory>(cat);

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(TbCategory cat)
        {
            try
            {
                TbCategory oldCat = ctx.TbCategories.FirstOrDefault(x => x.CategoryId == cat.CategoryId);

                oldCat.CategoryId = cat.CategoryId;

                oldCat.CategoryName = cat.CategoryName;

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public TbCategory GetById(int id)
        {
            return ctx.TbCategories.FirstOrDefault(x=>x.CategoryId == id);
        }

        public List<TbCategory> GetCategories()
        {
            return ctx.TbCategories.ToList();
        }
    }
}
