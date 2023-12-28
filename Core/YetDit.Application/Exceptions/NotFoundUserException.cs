namespace YetDit.Application.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException() : base("Kullanıcı Adı veya Şifre Hatalı!")
        {

        }

        public NotFoundUserException(string errorMessage)
        {

        }
    }
}
