using AutoMapper;

using Application.Commands.GenreService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Genre, GenreResponse>().ReverseMap();
            CreateMap<Genre, CreateGenreCommand>().ReverseMap();
            CreateMap<Genre, UpdateGenreCommand>().ReverseMap();
          
        }
    }
}
