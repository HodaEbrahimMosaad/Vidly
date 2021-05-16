using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Dtos;
using VidllyApp.Mappers;
using VidllyApp.Models;

namespace VidllyApp.App_Start
{
    public static class AutoMap
    {
        public static IMapper Mapper { get; set; }

        public static void RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(
               config =>
               {
                   config.AddProfile<CustomerProfile>();
                   config.AddProfile<MembershipTypeProfile>();
                   config.AddProfile<MoviesProfile>();
                   config.AddProfile<GenreProfile>();
               });

            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}