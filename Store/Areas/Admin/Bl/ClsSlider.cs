using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Store.Models;

namespace Store.Areas.Admin.Bl
{
    public interface IClsSlider
    {
        List<TbSlider> GetSliders();
        TbSlider GetById(int id);
        bool Add(TbSlider slider);
        bool Edit(TbSlider slider);
        bool Delete(int sliderId);

    }
    public class ClsSlider : IClsSlider
    {
        StoreContext ctx;
        public ClsSlider(StoreContext service)
        {
            ctx = service;
        }
        public bool Add(TbSlider slider)
        {
            try
            {
                //ctx.Add<TbSlider>(slider);
                ctx.TbSlider.Add(slider);

                ctx.SaveChanges();

                return true;
            }
            catch(Exception )
            {
                return false;
            }
        }

        public bool Delete(int sliderId)
        {
            try
            {
                TbSlider slider = ctx.TbSlider.FirstOrDefault(x => x.SliderId == sliderId);

                ctx.Remove<TbSlider>(slider);

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(TbSlider slider)
        {
            try
            {
                TbSlider oldSlider = ctx.TbSlider.FirstOrDefault(x => x.SliderId == slider.SliderId);

                oldSlider.SliderId = slider.SliderId;

                oldSlider.Descreption = slider.Descreption;

                oldSlider.LongDescreption = slider.LongDescreption;

                if(slider.SliderImage != null)
                    oldSlider.SliderImage = slider.SliderImage;

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public TbSlider GetById(int id)
        {
           return ctx.TbSlider.FirstOrDefault(x=>x.SliderId == id);
        }

        public List<TbSlider> GetSliders()
        {
            return ctx.TbSlider.ToList();
        }
    }
}
