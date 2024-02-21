using MediatR;
using Application.Responses;

namespace Application.Queries.GenreService
{
    public class GetGenreByIdQuery : IRequest<GenreResponse>
    {
        public int id { get; set; }

        public GetGenreByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
