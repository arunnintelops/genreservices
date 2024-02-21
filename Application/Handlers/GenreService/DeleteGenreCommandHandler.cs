using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.GenreService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.GenreService
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<DeleteGenreCommandHandler> _logger;

        public DeleteGenreCommandHandler(IGenreRepository genreRepository, ILogger<DeleteGenreCommandHandler> logger)
        {
            _genreRepository = genreRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genreToDelete = await _genreRepository.GetByIdAsync(request.Id);
            if (genreToDelete == null)
            {
                throw new GenreNotFoundException(nameof(Genre), request.Id);
            }

            await _genreRepository.DeleteAsync(genreToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
