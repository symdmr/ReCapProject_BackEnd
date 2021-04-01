﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, 
                                 ColorName = co.ColorName, DailyPrice = c.DailyPrice
                                 , ModelYear=c.ModelYear, Description=c.Description };
                return result.ToList();
            }
        }
    }
    //ICarDal benden implemente istiyor, ben de olayın EfEntityRepositoryBase'de bittiğini söylüyorum
    //Business ICarDal'a bağlı, ICarDal'a özel operasyonlar gelecek, car için implemente edilecek özel operasyonlar olabilir yani
}
