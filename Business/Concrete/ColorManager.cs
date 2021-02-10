using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.ColorId > 0)
            {
                _colorDal.Add(color);
                Console.WriteLine("color succesfully added\n");
            }
            else
            {
                Console.WriteLine("{0} : not a valid color\n", color.ColorId);
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("color succesfully deleted\n");
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("color succesfully updated\n");
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(p => p.ColorId == id);
        }

        public List<Color> GetAll()
        {
            Console.WriteLine("ALL COLORS\n");
            return _colorDal.GetAll();
        }
    }
}
