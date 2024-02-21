using AutoMapper;
using MediatR;
using Application.Queries.GenreService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.GenreService
{
    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, List<GenreResponse>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GetAllGenresQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<List<GenreResponse>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var generatedGenre = await _genreRepository.GetAllAsync();
            var genreEntity = _mapper.Map<List<GenreResponse>>(generatedGenre);
            return genreEntity;
        }
    }
}
