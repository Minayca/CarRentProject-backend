using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if ((_colorDal.GetAll().Any(c => c.ColorName == color.ColorName)) == false)
            {
                _colorDal.Add(color);
                Console.WriteLine("Renk başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lütfen veritabanında olmayan bir renk giriniz!");
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Renk başarıyla silindi.");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Renk başarıyla güncellendi.");
        }
    }
}