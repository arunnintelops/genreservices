using AutoMapper;
using Moq;
using Application.Handlers.GenreService;
using Application.Queries.GenreService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.GenreService
{
    public class GetGenreByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsGenreResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new Genre { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IGenreRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetGenreByIdQuery(Id);
            var handler = new GetGenreByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GenreResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
