using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        void DeleteUser(int id);
    }
}
