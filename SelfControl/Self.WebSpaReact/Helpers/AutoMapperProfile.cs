using AutoMapper;
using Self.Core.Entities;
using Self.WebSpaReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Self.WebSpaReact.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterUserModel, User>();
        }
    }
}
