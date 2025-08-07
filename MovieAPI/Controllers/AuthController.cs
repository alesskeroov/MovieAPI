using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.AppDbContext;
using MovieAPI.Dtos;
using MovieAPI.Entities;
using MovieAPI.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly MovieDbContext _db;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(MovieDbContext db, IConfiguration config,IMapper mapper)
        {
            _db = db;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == dto.Username && u.Password == dto.Password);
            if (user == null)
                return Unauthorized("İstifadəçi tapılmadı və ya şifrə yalnışdır");

            // 1. Claim-lər
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // 2. Security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Token yaradılır
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = jwt });
        }
        [HttpPost]
        public IActionResult Register(RegisterDto dto)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == dto.Username);
            if (user != null)
            {
                return BadRequest("İstifadəçi artıq mövcuddur");
            }

            var newUser = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = "User"
            };

            _db.Users.Add(newUser);
            _db.SaveChanges();

            return Ok("Qeydiyyat uğurlu");
        }




    }
}
