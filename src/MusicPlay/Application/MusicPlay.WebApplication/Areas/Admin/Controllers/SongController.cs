using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MisicPlay.Models;

using MusicPlay.Database;

namespace MusicPlay.WebApplication.Areas.Admin.Controllers
{
    public class SongController : BaseAdminController
    {
        public SongController(MusicPlayDbContext dbContext)
            :base(dbContext)
        {
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Song song)
        {
            song.CreatedOn = DateTime.UtcNow;

            this.DbContext.Songs.Add(song);

            this.DbContext.SaveChanges();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult All()
        {
            var allSongs = this.DbContext.Songs.ToArray();


            return this.View();
        }
    }
}
