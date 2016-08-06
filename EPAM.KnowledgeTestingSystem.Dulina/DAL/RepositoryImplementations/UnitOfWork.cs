using DAL.Repository;
using System;
using System.Data.Entity;

namespace DAL.RepositoryImplementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
