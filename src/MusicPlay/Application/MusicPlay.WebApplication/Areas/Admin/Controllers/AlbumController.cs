using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MisicPlay.Models;

using MusicPlay.Constants.Application;
using MusicPlay.Database;

namespace MusicPlay.WebApplication.Areas.Admin.Controllers
{
    public class AlbumController : BaseAdminController
    {
        public AlbumController(MusicPlayDbContext dbContext) 
            : base(dbContext)
        {
        }


        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(album);
            }

            album.CreatedOn = DateTime.UtcNow;

            this.DbContext.Albums.Add(album);

            this.DbContext.SaveChanges();

            return RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult All()
        {


            return this.View();
        }
    }
}
