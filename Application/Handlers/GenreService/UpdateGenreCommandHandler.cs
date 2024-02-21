using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.GenreService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.GenreService
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGenreCommandHandler> _logger;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper, ILogger<UpdateGenreCommandHandler> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreToUpdate = await _genreRepository.GetByIdAsync(request.Id);
            if (genreToUpdate == null)
            {
                throw new GenreNotFoundException(nameof(Genre), request.Id);
            }

            _mapper.Map(request, genreToUpdate, typeof(UpdateGenreCommand), typeof(Genre));
            await _genreRepository.UpdateAsync(genreToUpdate);
            _logger.LogInformation($"Genre is successfully updated");
        }
    }
}
