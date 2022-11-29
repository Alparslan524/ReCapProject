﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarServices
    {
        List<Car> GetAll();
        List<Car> GetByDailyPrice(decimal min,decimal max);
        public List<CarDetailDto> GetCarDetailDtos();
    }
}
