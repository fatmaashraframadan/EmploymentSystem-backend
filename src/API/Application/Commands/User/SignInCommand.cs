using MediatR;

namespace API.Application.Commands.User
{
    public class SignInCommand : IRequest<SignInResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public SignInCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class SignInResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMsg { get; set; } = "";
    }
}