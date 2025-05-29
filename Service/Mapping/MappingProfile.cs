using AutoMapper;
using Data.Entities;
using Service.DTOs;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
} 