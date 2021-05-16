using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Dtos;
using VidllyApp.Models;

namespace VidllyApp.Mappers
{
    public class GenreProfile: Profile
    {
        public GenreProfile()
        {
            
            this.CreateMap<Genre, GenreModel>()
                .ReverseMap()
        .ForMember(t => t.Id, opt => opt.Ignore());
            
        }

    }
}