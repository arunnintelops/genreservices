using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.GenreService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.GenreService
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateGenreCommandHandler> _logger;

        public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper, ILogger<CreateGenreCommandHandler> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreEntity = _mapper.Map<Genre>(request);

            /*****************************************************************************/
            var generatedGenre = await _genreRepository.AddAsync(genreEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedGenre} successfully created.");
            return generatedGenre.Id;
        }
    }
}
