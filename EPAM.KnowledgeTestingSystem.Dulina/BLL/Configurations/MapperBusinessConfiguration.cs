using System;
using AutoMapper;
using BLL.Entities;
using DAL.DataTransferObject;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ORM;

namespace BLL.Configurations
{
    public class MapperBusinessConfiguration
    {
        public static IMapper MapperInstance { get; private set; }

        static MapperBusinessConfiguration()
        {
            Configure();
        }

        private static void Configure()
        {
            MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, DalUser>().ReverseMap();
                cfg.CreateMap<RoleEntity, DalRole>().ReverseMap();
                cfg.CreateMap<TestEntity, DalTest>().ReverseMap();
                cfg.CreateMap<QuestionEntity, DalQuestion>().ReverseMap();
                cfg.CreateMap<AnswerEntity, DalAnswer>().ReverseMap();
                cfg.CreateMap<ExtraUserInformationEntity, DalExtraUserInformation>().ReverseMap();
                cfg.CreateMap<Expression<Func<TestEntity, bool>>, Expression<Func<DalTest, bool>>>().ReverseMap();
                cfg.CreateMap<IQueryable<DalTest>, IQueryable<TestEntity>>().ReverseMap();
                //cfg.CreateMap<IEnumerable<TestEntity>, IEnumerable<DalTest>>().ReverseMap();
            }).CreateMapper();
        }
    }
}
