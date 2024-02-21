using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.GenreService;
using Application.Exceptions;
using Application.Handlers.GenreService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.GenreService
{
    public class DeleteGenreCommandHandlerTests
    {
        private readonly Mock<IGenreRepository> _genreRepository;
        private readonly Mock<ILogger<DeleteGenreCommandHandler>> _logger;

        public DeleteGenreCommandHandlerTests()
        {
            _genreRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsGenreNotFoundExceptionWhenGenreNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteGenreCommand { Id = Id }; // Create a request object

            _genreRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Genre)null); // Mock the repository to return null

            var handler = new DeleteGenreCommandHandler(_genreRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<GenreNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
