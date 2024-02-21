namespace Application.Exceptions
{
    public class GenreNotFoundException : ApplicationException
    {
        public GenreNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
