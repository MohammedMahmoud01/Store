using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Areas.Admin.Models;
using Store.Models;

using Microsoft.EntityFrameworkCore;
using Domains;

namespace Store.Areas.Admin.Bl
{
    public interface IClsItemImage
    {
        List<ItemImageModel> GetAllImages();
        TbImage GetById(int id);
        bool Add(TbImage image);
        bool Edit(TbImage image);
        bool Delete(int imageId);
    }
    public class ClsItemImage : IClsItemImage
    {
        StoreContext ctx;
        public ClsItemImage(StoreContext service)
        {
            ctx = service;
        }

        public bool Add(TbImage image)
        {
            try
            {
                ctx.Add<TbImage>(image);

                //ctx.TbImage.Add(image);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Delete(int imageId)
        {
            try
            {
                TbImage image = ctx.TbImages.FirstOrDefault(x => x.ImageId == imageId);

                ctx.Remove<TbImage>(image);

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
   
        }

        public bool Edit(TbImage image)
        {
            try
            {
                TbImage oldImage = ctx.TbImages.FirstOrDefault(x => x.ImageId == image.ImageId);

                oldImage.ImageId = image.ImageId;

                oldImage.ImageName = image.ImageName;

                if(image.ImageName != null)
                    oldImage.ItemId = image.ItemId;

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ItemImageModel> GetAllImages()
        {
            var query = from itemImage in ctx.TbImages
                        join item in ctx.TbItems
                        on itemImage.ItemId equals item.ItemId
                        select new ItemImageModel
                        {
                            ItemId = itemImage.ItemId,
                            ImageId = itemImage.ImageId,
                            ImageName = itemImage.ImageName,
                            ItemName = item.ItemName
                        };
            return query.ToList();
        }

        public TbImage GetById(int id)
        {
            return ctx.TbImages.FirstOrDefault(x=>x.ImageId == id);
        }
    }
}
