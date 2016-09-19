using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.DataTransferObject;

namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> objectToFind);
        void Create(TEntity entity);
        void DeleteById(int id);
        void Update(TEntity entity);
    }
}
