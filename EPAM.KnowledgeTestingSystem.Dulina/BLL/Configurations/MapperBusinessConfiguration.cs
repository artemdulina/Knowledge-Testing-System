using AutoMapper;
using BLL.Entities;
using DAL.DataTransferObject;
using System.Collections.Generic;

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
            }).CreateMapper();
        }
    }
}
