using System;
using DAL.DataTransferObject;
using ORM;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Configurations
{
    public static class MapperDomainConfiguration
    {
        public static IMapper MapperInstance { get; private set; }

        static MapperDomainConfiguration()
        {
            Configure();
        }

        public static void Configure()
        {
            MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, DalUser>().ReverseMap();
                cfg.CreateMap<Role, DalRole>().ReverseMap();
                cfg.CreateMap<Test, DalTest>().ReverseMap();
                cfg.CreateMap<Question, DalQuestion>().ReverseMap();
                cfg.CreateMap<Answer, DalAnswer>().ReverseMap();
                cfg.CreateMap<ExtraUserInformation, DalExtraUserInformation>().ReverseMap();
                cfg.CreateMap<Expression<Func<DalTest, bool>>, Expression<Func<Test, bool>>>().ReverseMap();
                cfg.CreateMap<IQueryable<Test>, IQueryable<DalTest>>().ReverseMap();
                //cfg.CreateMap<IEnumerable<Test>, IEnumerable<DalTest>>().ReverseMap();
            }).CreateMapper();
        }
    }
}
