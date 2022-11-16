using CodeBluCore;

namespace CodeBluMovil.Services
{
    public interface ILoginService
    {
        UserDTO User { get; }
        Task<string> Auth(UserDTO user);
    }
}
