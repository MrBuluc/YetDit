namespace YetDit.Application.Exceptions
{
    public class NotFoundPostException : Exception
    {
        public NotFoundPostException() : base("Post Bulunamadı!") { }

        public NotFoundPostException(string message) : base(message) { }
    }
}
