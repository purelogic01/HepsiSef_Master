﻿using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HepsiSef.Core.BaseRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(Guid Id);
        T GetById(Guid Id, params Expression<Func<T, object>>[] includes);
        T FirstOrDefaultBy(Expression<Func<T, bool>> exp);
        T FirstOrDefaultBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);
        bool Any(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        int Count();
        int Count(Expression<Func<T, bool>> exp);
        IQueryable<T> GetBy(Expression<Func<T, bool>> exp);
        IQueryable<T> GetBy(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);

        //RANGE OPERATIONS
        void AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        void DeleteRange(List<T> entities);


        void Save();

    }
}
