using System;
using AutoMapper;
using BLL.Entities;
using MvcKnowledgeSystem.Models;

namespace MvcKnowledgeSystem.Configurations
{
    public class MapperMvcConfiguration
    {
        public static IMapper MapperInstance { get; private set; }

        static MapperMvcConfiguration()
        {
            Configure();
        }

        private static void Configure()
        {
            MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestViewModel, TestEntity>()
                    .ForMember(entity => entity.TimeLimit, expr => expr.MapFrom(src => TimeSpan.FromMinutes(src.TimeLimit)));
                cfg.CreateMap<QuestionViewModel, QuestionEntity>().ReverseMap();
                cfg.CreateMap<AnswersViewModel, AnswerEntity>().ReverseMap();
            }).CreateMapper();
        }
    }
}