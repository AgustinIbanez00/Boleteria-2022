using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface IUsuarioService
{
    Task<WebResult<ICollection<UsuarioResponse>>> GetUsuariosAsync();
    Task<WebResult<UsuarioResponse>> GetUsuarioAsync(int id);
    Task<WebResult<UsuarioResponse>> GetUsuarioByEmailAsync(string email);
    Task<WebResult<UsuarioResponse>> GetUsuarioByUserNameAsync(string userName);
    Task<WebResult<UsuarioResponse>> CreateUsuarioAsync(RegistroRequest request);
    Task<WebResult<UsuarioResponse>> LockUsuarioAsync(int id);
    Task<WebResult<LoginResponse>> LoginUsuarioAsync(LoginRequest request);
}
