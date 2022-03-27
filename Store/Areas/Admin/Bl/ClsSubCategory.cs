using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Areas.Admin.Bl
{
    public interface IClsSubCategory
    {
        List<TbSubCategory> GetSubCategories();
        List<TbCategory> GetCategories();
        TbSubCategory GetById(int id);
        bool Add(TbSubCategory cat);
        bool Edit(TbSubCategory cat);
        bool Delete(int catId);
    }
    public class ClsSubCategory : IClsSubCategory
    {
        StoreContext ctx;
        public ClsSubCategory(StoreContext service)
        {
            ctx = service;
        }
        public bool Add(TbSubCategory cat)
        {
            try
            {
                ctx.Add<TbSubCategory>(cat);

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
                TbSubCategory subCategory = ctx.TbSubCategories.FirstOrDefault(x => x.SubCategoryId == catId);

                ctx.TbSubCategories.Remove(subCategory);

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(TbSubCategory cat)
        {
            try
            {
                TbSubCategory oldSubCategory = GetById(cat.SubCategoryId);

                oldSubCategory.SubCategoryId = cat.SubCategoryId;

                oldSubCategory.SubCategoryName = cat.SubCategoryName;

                oldSubCategory.CategoryId = cat.CategoryId;

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public TbSubCategory GetById(int id)
        {
            return ctx.TbSubCategories.FirstOrDefault(x=>x.SubCategoryId == id);
        }

        public List<TbSubCategory> GetSubCategories()
        {
            return ctx.TbSubCategories.Include(x=>x.Category).ToList();
        }
        public List<TbCategory> GetCategories()
        {
            return ctx.TbCategories.ToList();
        }
    }
}
