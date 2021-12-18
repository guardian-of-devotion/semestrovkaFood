using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Semestrovka_3._0.Pages.DataConnection;
using Semestrovka_3._0.Models;
using Semestrovka_3._0.Pages.Options;
using Semestrovka_3._0.Pages.Security;
using Semestrovka_3._0.Pages.Services;


namespace Semestrovka_3._0.Pages.Controllers
{
    public class AuthController : Controller
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private AppDbContext _context;

        public AuthController(IOptions<AuthOptions> options, AppDbContext context)
        {
            _authOptions = options;
            _context = context;
        }

        [HttpGet]
        public IActionResult Authorization() => View();

        [HttpGet]
        public IActionResult Registration() => View();
       


        [HttpPost]
        public IActionResult Registration([FromForm] string name, [FromForm] string surname, [FromForm] string email,
           [FromForm] string password, [FromForm] string confirmPassword)
        {
            
            _context.SaveChanges();

            var user = UserExists(email);
            if (user != null)
            {
                return Ok("Такой пользователь уже существует!");
            }


            if (password != confirmPassword)
            {
                return Ok("Пароли не совпадают!");
            }

            user = new User {
                UserId = Guid.NewGuid(),
                Email = email,
                Password = PassHash.Encrypt(password),
                Name = name,
                Surname = surname,
            };

            

            ViewBag.AuthStatus = "Регистрация прошла успешно!";
             return View("AuthStatus");
        }

        [HttpPost]

        public IActionResult Authorization([FromForm] string email, [FromForm] string password)
        {
            var pwd = PassHash.Encrypt(password);
            var user = AuthenticateUser(email, pwd);

            if (user == null)
                return Unauthorized();

            var token = JwtGenerate(user);

            if (!HttpContext.Session.Keys.Contains("user"))
                HttpContext.Session.Set("user", user);

            ViewBag.AuthStatus =
                "Авторизация прошла успешно!";

            return View("AuthStatus");
            return RedirectToAction("_Layout", "Shared");

        }
   

        private User AuthenticateUser(string email, string password) =>
            _context.User.FirstOrDefault(usr => usr.Email == email && usr.Password == password);

        private User UserExists(string email) =>
            _context.User.FirstOrDefault(usr => usr.Email == email);


        private string JwtGenerate(User user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Password),
            };

            var token = new JwtSecurityToken(
                authParams.TokenCreator,
                authParams.TokenUser,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}