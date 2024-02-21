using MediatR;

namespace Application.Commands.GenreService
{
    public class CreateGenreCommand : IRequest<int>
    {
        public int Id  { get; set; }
    
        
        public string Keywords { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public bool Suggested { get; set; }
        
    
    }
}
