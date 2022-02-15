using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions.Hashing;
using BoleteriaOnline.Web.Repositories;
using EntityFramework.Exceptions.Common;
using Microsoft.IdentityModel.Tokens;

namespace BoleteriaOnline.Web.Services;

using static WebResponse;
public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public async Task<WebResult<UsuarioResponse>> CreateUsuarioAsync(RegistroRequest request)
    {
        try
        {
            if (await _usuarioRepository.ExistsUsuarioByEmailAsync(request.Email))
                return KeyError<UsuarioResponse>(nameof(request.Email), $"Esa dirección de correo electrónico {request.Email} ya existe.");

            var usuario = _mapper.Map<Usuario>(request);
            HashedPassword hashedPassword = request.Password.Hash();
            usuario.Password = hashedPassword.Password;
            usuario.Salt = hashedPassword.Salt;

            if (!await _usuarioRepository.CreateUsuarioAsync(usuario))
                return Error<Usuario, UsuarioResponse>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<UsuarioResponse>(usuario);
            return Ok<Usuario, UsuarioResponse>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Usuario, UsuarioResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Usuario, UsuarioResponse>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<UsuarioResponse>> LockUsuarioAsync(int id)
    {
        try
        {
            var usuario = await _usuarioRepository.GetUsuarioAsync(id);
            if (usuario == null)
                return Error<Usuario, UsuarioResponse>(ErrorMessage.NotFound);

            if (usuario.LockoutEnabled)
                return Error<UsuarioResponse>("La cuenta de este usuario se encuentra bloqueada.");

            return await _usuarioRepository.LockUsuarioAsync(id) ? Ok<UsuarioResponse>() : Error<UsuarioResponse>("No se pudo bloquear a ese usuario.");
        }
        catch (Exception ex)
        {
            return Error<Usuario, UsuarioResponse>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<UsuarioResponse>> GetUsuarioAsync(int id)
    {
        try
        {
            var usuario = await _usuarioRepository.GetUsuarioAsync(id);

            if (usuario == null)
                return Error<Usuario, UsuarioResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<UsuarioResponse>(usuario));
        }
        catch (Exception ex)
        {
            return Error<Usuario, UsuarioResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<UsuarioResponse>> GetUsuarioByEmailAsync(string email)
    {
        try
        {
            var usuario = await _usuarioRepository.GetUsuarioByEmailAsync(email);

            if (usuario == null)
                return Error<Usuario, UsuarioResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<UsuarioResponse>(usuario));
        }
        catch (Exception ex)
        {
            return Error<Usuario, UsuarioResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<UsuarioResponse>> GetUsuarioByUserNameAsync(string userName)
    {
        try
        {
            var usuario = await _usuarioRepository.GetUsuarioByUserNameAsync(userName);

            if (usuario == null)
                return Error<Usuario, UsuarioResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<UsuarioResponse>(usuario));
        }
        catch (Exception ex)
        {
            return Error<Usuario, UsuarioResponse>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ICollection<UsuarioResponse>>> GetUsuariosAsync()
    {
        try
        {
            var usuarios = await _usuarioRepository.GetUsuariosAsync();

            var usuariosDto = new List<UsuarioResponse>();

            foreach (var usuario in usuarios)
            {
                usuariosDto.Add(_mapper.Map<UsuarioResponse>(usuario));
            }
            return Ok<ICollection<UsuarioResponse>>(usuariosDto);
        }
        catch (Exception ex)
        {
            return Error<Usuario, ICollection<UsuarioResponse>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<LoginResponse>> LoginUsuarioAsync(LoginRequest request)
    {
        try
        {
            Usuario usuario = await _usuarioRepository.GetUsuarioByEmailAsync(request.Email);

            if (usuario == null)
                return KeyError<Usuario, LoginResponse>(nameof(request.Email), ErrorMessage.InvalidEmail);

            if (usuario.LockoutEnabled)
                return Error<LoginResponse>("Esta cuenta se encuentra bloqueada.");

            if (HashingExtensions.CheckHash(request.Password, usuario.Password, usuario.Salt))
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));
                claims.AddClaim(new Claim(ClaimTypes.Role, usuario.Tipo.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                string bearer_token = tokenHandler.WriteToken(createdToken);

                return Ok(new LoginResponse() { Token = bearer_token });
            }

            return KeyError<Usuario, LoginResponse>(nameof(request.Password), ErrorMessage.InvalidPassword);
        }
        catch (Exception ex)
        {
            return Error<Usuario, LoginResponse>(ErrorMessage.Generic, ex.Message);
        }
    }

}
