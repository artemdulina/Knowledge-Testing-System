using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Repository;
using DAL.DataTransferObject;
using System.Data.Entity;

namespace DAL.RepositoryImplementations
{
    public class GlobalRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext context;

        public GlobalRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(TEntity entity)
        {
            /*TEntity entityt = ObjectMapperManager.DefaultInstance.GetMapper<TEntity, TEntity>(MapperDomainConfiguration.Configuration)
                .Map
            context.Set<TEntity>().Add(entity);*/
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity GetByPredicate(Expression<Func<TEntity, bool>> objectToFind)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
