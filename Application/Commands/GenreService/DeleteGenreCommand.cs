using MediatR;

namespace Application.Commands.GenreService
{
    public class DeleteGenreCommand : IRequest
    {
        public int Id { get; set; }
    }
}
