namespace YetDit.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity) : base($"{entity} Bulunamadı!") { }
    }
}
