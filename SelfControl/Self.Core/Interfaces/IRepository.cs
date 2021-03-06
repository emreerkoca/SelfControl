﻿using Self.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetList();
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
