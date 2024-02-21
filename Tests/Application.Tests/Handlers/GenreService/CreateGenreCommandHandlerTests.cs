using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.GenreService;
using Application.Handlers.GenreService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.GenreService
{
    public class CreateGenreCommandHandlerTests
    {
        private readonly Mock<IGenreRepository> _genreRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateGenreCommandHandler>> _logger;

        public CreateGenreCommandHandlerTests()
        {
            _genreRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateGenreCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Genre>(request))
                .Returns(new Genre()); 

            _genreRepository
                .Setup(r => r.AddAsync(It.IsAny<Genre>()))
                .ReturnsAsync(new Genre { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateGenreCommandHandler>>();
            var handler = new CreateGenreCommandHandler(_genreRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
