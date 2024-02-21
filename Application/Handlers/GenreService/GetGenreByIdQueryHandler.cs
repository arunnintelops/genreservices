using AutoMapper;
using MediatR;
using Application.Queries.GenreService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.GenreService
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreResponse>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GetGenreByIdQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<GenreResponse> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedGenre = await _genreRepository.GetByIdAsync(request.id);
            var genreEntity = _mapper.Map<GenreResponse>(generatedGenre);
            return genreEntity;
        }
    }
}
