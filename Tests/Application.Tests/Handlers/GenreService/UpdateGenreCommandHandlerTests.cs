using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.GenreService;
using Application.Exceptions;
using Application.Handlers.GenreService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.GenreService
{
    public class UpdateGenreCommandHandlerTests
    {
        private readonly Mock<IGenreRepository> _genreRepository;
        private readonly Mock<ILogger<UpdateGenreCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateGenreCommandHandlerTests()
        {
            _genreRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsGenreNotFoundExceptionWhenGenreNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateGenreCommand { Id = Id }; // Create a request object

            _genreRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Genre)null); // Mock the repository to return null

            var handler = new UpdateGenreCommandHandler(_genreRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<GenreNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
