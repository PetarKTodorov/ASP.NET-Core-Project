using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MisicPlay.Models;

using MusicPlay.Database;

namespace MusicPlay.WebApplication.Areas.Admin.Controllers
{
    public class AuthorController : BaseAdminController
    {
        public AuthorController(MusicPlayDbContext dbContext)
            : base(dbContext)
        {
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (this.ModelState.IsValid == false)
            {
                this.View(author);
            }

            author.CreatedOn = DateTime.UtcNow;

            this.DbContext.Authors.Add(author);

            this.DbContext.SaveChanges();

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult All()
        {
            var allAuthors = this.DbContext.Authors
                .Include(a => a.AlbumsAuthorsMapping)
                .ToArray();

            return View(allAuthors);
        }
    }
}
