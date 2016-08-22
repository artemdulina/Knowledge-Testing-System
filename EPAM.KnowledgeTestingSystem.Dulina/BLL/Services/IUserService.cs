using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        UserEntity GetUserEntity(string name);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        void DeleteUser(int id);
        void Update(UserEntity entity);
        void Update(ExtraUserInformationEntity entity);
    }
}
