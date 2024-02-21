using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.GenreService;
using Application.Queries.GenreService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GenreServiceController> _logger;
        public GenreServiceController(IMediator mediator, ILogger<GenreServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateGenre")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateGenre([FromBody] CreateGenreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllGenres")]
        [ProducesResponseType(typeof(IEnumerable<List<GenreResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GenreResponse>>> GetAllGenres(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllGenresQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetGenreById")]
        [ProducesResponseType(typeof(GenreResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GenreResponse>> GetGenreById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genre GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetGenreByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdateGenre")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateGenre([FromBody] UpdateGenreCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
        [HttpDelete("{id}", Name = "DeleteGenre")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            _logger.LogInformation("Genre DELETE request received for ID {id}", id);
            var cmd = new DeleteGenreCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }
        
    }
}
