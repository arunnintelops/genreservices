using AutoMapper;
using Moq;
using Application.Handlers.GenreService;
using Application.Queries.GenreService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.GenreService
{
    public class GetAllGenresQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfGenreResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Genre> 
        {
            new Genre { Id = 1 },
            new Genre { Id = 2 }

        };

            var RepositoryMock = new Mock<IGenreRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllGenresQuery();
            var handler = new GetAllGenresQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<GenreResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
