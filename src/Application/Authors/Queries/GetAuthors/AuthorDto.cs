using AutoMapper;
using DWork.CollegeSystem.Application.Common.Extensions;
using DWork.CollegeSystem.Application.Common.Mappings;
using DWork.CollegeSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWork.CollegeSystem.Application.Authors.Queries.GetAuthors
{
    public class AuthorDto : IMapFrom<Author>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MainCategory { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge(src.DateOfDeath)));
        }
    }
}
