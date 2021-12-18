using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Semestrovka_3._0.Pages.DataConnection;
using Semestrovka_3._0.Models;
using Semestrovka_3._0.Pages.Security;
using Semestrovka_3._0.Pages.Services;

namespace Semestrovka_3._0.Pages.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context) => _context = context;

        private bool IsCurrentUserExists() =>
                HttpContext.Session.Keys.Contains("user");

        private User GetCurrentUser() =>
            HttpContext.Session.Get<User>("user");
    }
}
