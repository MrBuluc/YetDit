namespace YetGit.Application.DTOs
{
    public class AuthenticationLoginResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<AuthenticationLoginResponseError> Errors { get; set; }
    }

    public class AuthenticationLoginResponseError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
