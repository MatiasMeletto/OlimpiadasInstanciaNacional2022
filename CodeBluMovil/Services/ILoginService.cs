using CodeBluCore;

namespace CodeBluMovil.Services
{
    public interface ILoginService
    {
        Task<bool> AutenticacionManual(UserDTO user);
    }
}
