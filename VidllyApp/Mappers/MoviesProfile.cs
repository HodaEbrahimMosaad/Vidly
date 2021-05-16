using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Dtos;
using VidllyApp.Models;

namespace VidllyApp.Mappers
{
    public class MoviesProfile: Profile
    {
        public MoviesProfile()
        {
            this.CreateMap<Movie, MoviesModel>()
                .ReverseMap()
        .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }

}