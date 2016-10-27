﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FitnessApp.Core
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<List<TEntity>> All(params Expression<Func<TEntity, object>>[] entitiesToInclude);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(int id);
        TEntity FindById(int id, params Expression<Func<TEntity, object>>[] entitiesToInclude);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude);
    }
}
