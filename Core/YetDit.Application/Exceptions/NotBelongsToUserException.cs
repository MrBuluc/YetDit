namespace YetDit.Application.Exceptions
{
    public class NotBelongsToUserException : Exception
    {
        public NotBelongsToUserException(string entity) : base($"{entity} Not Belongs To User Error")
        {

        }

        public NotBelongsToUserException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
