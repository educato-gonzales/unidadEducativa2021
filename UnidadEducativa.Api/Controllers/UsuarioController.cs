using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UnidadEducativa.Api.Helpers;
using UnidadEducativa.Api.Responses;
using UnidadEducativa.Core.DTO;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;
using UnidadEducativa.Infrastructure.Data;


namespace UnidadEducativa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly colegioContext _context;
        private readonly AppSettings _appSettings;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, colegioContext context, IOptions<AppSettings> appSettings)
        {

            _context = context;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        //[Authorize]
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioService.GetUsuarios();
            var usuarioDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            var response = new ApiResponse<IEnumerable<UsuarioDto>>(usuarioDtos);
            return Ok(response);
        }

        public Usuario GetById(long id)
        {
            return _context.Usuario.FirstOrDefault(x => x.Id == id);
        }

        // GET: api/Usuarios/Nombre/Clave
        [HttpGet("{nombre}/{clave}")]
        public ActionResult<Usuario> GetUsuario(string nombre, string clave)
        {
            var usuario = _context.Usuario.FirstOrDefault(ele => ele.Nombre == nombre && ele.Clave == clave);
            if (usuario == null)
            {
                return NotFound();
            }
            var token = generateJwtToken(usuario);
            usuario.Token = token;
            return usuario;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUsuario(long Id)
        {
            var usuario = await _usuarioService.GetUsuario(Id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioService.InsertUsuario(usuario);

            usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Id = Id;
            var result = await _usuarioService.UpdateUsuario(usuario);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _usuarioService.DeleteUsuario(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
       
        private string generateJwtToken(Usuario user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
