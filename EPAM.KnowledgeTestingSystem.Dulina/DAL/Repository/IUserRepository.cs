using System;
using DAL.DataTransferObject;

namespace DAL.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser Get(string name);
        void UpdateExtraInfo(DalExtraUserInformation information);
    }
}
