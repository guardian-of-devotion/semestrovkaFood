using Microsoft.AspNetCore.Mvc;
using Semestrovka_3._0.Models;
using Semestrovka_3._0.Pages.DataConnection;

namespace Semestrovka_3._0.Pages.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context) =>
            _context = context;

        public IActionResult Index()
        {
            return View();
        }

            public IActionResult Profile(int userId)
            {
                var currentUser = HttpContext.Items["User"] as User;
                var user = userId is default(int)
                    ? currentUser
                    : _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user is null) return BadRequest();
                var comments = _context.Comments
                    .Where(c => c.UserId == user.UserId)
                    .Select(c => new BetterComment
                    {
                        Id = c.Id,
                        Text = c.Text,
                        Writer = _context.Users.FirstOrDefault(u => u.UserId == c.WriterId)!
                    }).ToList();

                return View(new ProfileModel
                {
                    IsCurrentUser = currentUser!.UserId == user.UserId,
                    CurrentUser = currentUser,
                    User = user,
                    Comments = comments
                });
            }
            public readonly struct BetterComment 
        {
            public int Id { get; init; }
            public string Text { get; init; }
            public User Writer { get; init; }
        }

        public readonly struct ProfileModel
        {
            public bool IsCurrentUser { get; init; }
            public User CurrentUser { get; init; }
            public User User { get; init; } = null!;
            public List<BetterComment> Comments { get; init; } = null!;
        }
    }

    }