using MediatR;

namespace Application.Commands.GenreService
{
    public class UpdateGenreCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public string Keywords { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public bool Suggested { get; set; }
        
    
    }
}
