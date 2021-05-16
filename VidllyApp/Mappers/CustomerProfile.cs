using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Dtos;
using VidllyApp.Models;

namespace VidllyApp.Mappers
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            this.CreateMap<Customer, CustomerModel>()
                .ReverseMap()
        .ForMember(t => t.MembershipType, opt => opt.Ignore())
        .ForMember(t => t.Id, opt => opt.Ignore());
        }
    }
}