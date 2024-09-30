﻿using OtoServisSatis.Data;
using OtoServisSatis.Entities;
using OtoServisSatis.Data.Concrete;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {
        }
    }
}