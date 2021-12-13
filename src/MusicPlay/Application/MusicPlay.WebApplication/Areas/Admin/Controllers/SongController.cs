using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MisicPlay.Models;

using MusicPlay.Constants.Application;
using MusicPlay.Database;

namespace MusicPlay.WebApplication.Areas.Admin.Controllers
{
    public class SongController : BaseAdminController
    {
        public SongController(MusicPlayDbContext dbContext)
            : base(dbContext)
        {

        }

        [HttpGet]
        public IActionResult Create()
        {
            var allAlbums = this.DbContext.Albums
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name,
                })
                .ToArray();


            this.ViewBag.Albums = allAlbums;

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Song song)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(song);
            }

            song.CreatedOn = DateTime.UtcNow;

            this.DbContext.Songs.Add(song);

            this.DbContext.SaveChanges();

            return RedirectToAction(nameof(this.All), this.GetType().Name.Replace("Controller", ""), new { area = ApplicationConstants.AdminArea });
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var song = this.DbContext.Songs.SingleOrDefault(s => s.Id == id);

            if (song == null)
            {
                return RedirectToAction(nameof(this.Create), this.GetType().Name.Replace("Controller", ""), new { area = ApplicationConstants.AdminArea });
            }

            var allAlbums = this.DbContext.Albums
                .ToArray();

            this.ViewBag.Albums = allAlbums;

            return this.View(song);
        }

        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(song);
            }

            song.UpdatedOn = DateTime.UtcNow;

            this.DbContext.Songs.Update(song);

            this.DbContext.SaveChanges();

            return RedirectToAction(nameof(this.All), this.GetType().Name.Replace("Controller", ""), new { area = ApplicationConstants.AdminArea });
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var song = this.DbContext.Songs.SingleOrDefault(s => s.Id == id);

            if (song.IsDeleted)
            {
                return RedirectToAction(nameof(this.All), this.GetType().Name.Replace("Controller", ""), new { area = ApplicationConstants.AdminArea });
            }

            if (song == null)
            {
                return RedirectToAction(nameof(this.Create), this.GetType().Name.Replace("Controller", ""), new { area = ApplicationConstants.AdminArea });
            }

            var allAlbums = this.DbContext.Albums
                .ToArray();

            this.ViewBag.Albums = allAlbums;

            return this.View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song song)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(song);
            }

            if (song.IsDeleted)
            {
                return RedirectToAction(nameof(this.All), this.GetType().Name.Replace("Controller", ""), new { area = ApplicationConstants.AdminArea });
            }

            song.UpdatedOn = DateTime.UtcNow;
            song.IsDeleted = true;
            song.DeletedOn = DateTime.UtcNow;

            this.DbContext.Songs.Update(song);

            this.DbContext.SaveChanges();

            return RedirectToAction(nameof(this.All), this.GetType().Name.Replace("Controller", ""), new { area = ApplicationConstants.AdminArea });
        }

        [HttpGet]
        public IActionResult All()
        {
            var allSongs = this.DbContext.Songs
                .Include(s => s.Album)
                .ToArray();


            return this.View(allSongs);
        }
    }
}
