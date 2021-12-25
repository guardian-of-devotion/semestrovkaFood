using Microsoft.AspNetCore.Mvc;
using Semestrovka_3._0.Models;
using Semestrovka_3._0.Pages.DataConnection;
using System.Linq;
using Semestrovka_3._0.Pages.Attributes;

namespace Semestrovka_3._0.Pages.Controllers;
    public class CommentsController : Controller
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context) =>
            _context = context;

        [HttpPost, Authorize]
        public IActionResult Comment(int userId, string name, string surname, string text)
        {
            _context.Comments.Add(new Comment
            {
                UserId = userId,
                WriterId = (HttpContext.Items["User"] as User)!.UserId,
                Text = text
            });
            _context.SaveChanges();
            return Ok();
        }
        [Authorize, HttpPost]
        public IActionResult Remove(int commentId)
        {
            Console.WriteLine($"removing comment {commentId}");
            var currentUser = HttpContext.Items["User"] as User;
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment is null || (comment.WriterId != currentUser!.UserId && comment.Id != currentUser.UserId))
                return BadRequest();
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return Ok();
        }
    }















  
