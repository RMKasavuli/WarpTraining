using Library.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.App_Start
{
    public class AutoMapperConfig
    {

        public static void RegisterAutoMapperConfig()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Business Mapping 
                cfg.CreateMap<Person, PersonModel>().ReverseMap();
            });

            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Business Mapping 
                cfg.CreateMap<Group, GroupModel>().ReverseMap();
            });
        }
    }
}