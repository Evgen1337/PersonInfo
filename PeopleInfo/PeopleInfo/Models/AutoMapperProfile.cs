using AutoMapper;
using PeopleInfo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleInfo.Models
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>();
        }

    }
}