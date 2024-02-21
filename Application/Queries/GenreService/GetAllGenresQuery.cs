using MediatR;
using Application.Responses;

namespace Application.Queries.GenreService
{
    public class GetAllGenresQuery : IRequest<List<GenreResponse>>
    {

    }
}
