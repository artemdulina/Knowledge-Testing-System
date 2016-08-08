﻿using System;
using System.Collections.Generic;
using BLL.Entities;
using BLL.Services;
using DAL.Repository;
using DAL.DataTransferObject;
using BLL.Configurations;

namespace BLL.ServicesImplementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            userRepository = repository;
        }

        public void CreateUser(UserEntity user)
        {
            DalUser userToCreate = MapperBusinessConfiguration.MapperInstance.Map<UserEntity, DalUser>(user);
            userRepository.Create(userToCreate);
            uow.Commit();
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteById(id);
            uow.Commit();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return MapperBusinessConfiguration.MapperInstance.
                Map<IEnumerable<DalUser>, IEnumerable<UserEntity>>(userRepository.GetAll());
        }

        public UserEntity GetUserEntity(int id)
        {
            return MapperBusinessConfiguration.MapperInstance.Map<DalUser, UserEntity>(userRepository.GetById(id));
        }
    }
}
