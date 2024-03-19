using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._00017259.DAL.DTOs;
using WAD._00017259.Models;

namespace WAD._00017259.DAL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Feedback, FeedbackDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<FeedbackDTO, Feedback>();
        }
    }
}
