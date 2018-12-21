using PeopleInfo.DAL;
using PeopleInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleInfo.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            //AutoMapper.Mapper.Initialize(config =>
            //{
            //    config.CreateMap<User, UserViewModel>()
            //            .ForMember(dest => dest.Id,
            //                    opt => opt.MapFrom(src => src.Id)) 
            //            .ForMember(dest => dest.Name,
            //                    opt => opt.MapFrom(src => src.Name))
            //            .ForMember(dest => dest.LastName,
            //                    opt => opt.MapFrom(src => src.LastName))
            //             .ForMember(dest => dest.FatherName,
            //                    opt => opt.MapFrom(src => src.FatherName))
            //            .ForMember(dest => dest.Email,
            //                    opt => opt.MapFrom(src => src.Email))
            //            .ForMember(dest => dest.Number,
            //                    opt => opt.MapFrom(src => src.Number))
            //            .ForMember(dest => dest.BirthDay,
            //                    opt => opt.MapFrom(src => src.BirthDay))
            //             .ForMember(dest => dest.Gender,
            //                    opt => opt.MapFrom(src => src.Gender))
            //            .ForMember(dest => dest.Inn,
            //                    opt => opt.MapFrom(src => src.Inn));

            //});
        }
    }
}