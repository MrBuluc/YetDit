namespace YetDit.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("Kullanıcı Oluşturulurken Beklenmedik Bir Hatayla Karşılaşıldı!")
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
