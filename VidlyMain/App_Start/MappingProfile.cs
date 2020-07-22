using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyMain.Dtos;
using VidlyMain.Models;

namespace VidlyMain.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movies, MoviesDto>();
            Mapper.CreateMap<MoviesDto, Movies>();
        }
    }
}