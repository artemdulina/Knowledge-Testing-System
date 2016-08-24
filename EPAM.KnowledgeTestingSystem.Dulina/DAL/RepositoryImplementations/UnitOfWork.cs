using DAL.Repository;
using NLog;
using System;
using System.Data.Entity;

namespace DAL.RepositoryImplementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
            //Context.Database.Log = s => logger.Info(s);
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
