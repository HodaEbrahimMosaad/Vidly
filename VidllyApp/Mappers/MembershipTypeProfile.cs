using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Dtos;
using VidllyApp.Models;

namespace VidllyApp.Mappers
{
    public class MembershipTypeProfile :Profile
    {
       
        public MembershipTypeProfile()
        {
            this.CreateMap<MembershipType, MembershipTypeModel>()
                .ReverseMap()
        .ForMember(m => m.Id, opt => opt.Ignore());
        }
        
    }
}