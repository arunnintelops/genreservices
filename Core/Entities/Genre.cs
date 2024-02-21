using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Genre : EntityBase
    {
        public int Id  { get; set; }
    
        
        public string Keywords { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public bool Suggested { get; set; }
        
    
    }
}
