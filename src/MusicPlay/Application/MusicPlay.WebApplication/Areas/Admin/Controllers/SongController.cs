using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MisicPlay.Models;

using MusicPlay.BindingModels;
using MusicPlay.Constants.Application;
using MusicPlay.Database;
using MusicPlay.Services.Album;
using MusicPlay.Services.Song;

namespace MusicPlay.WebApplication.Areas.Admin.Controllers
{
    public class SongController : BaseAdminController
    {
        private readonly IAlbumService albumService;
        private readonly ISongService songService;

        public SongController(MusicPlayDbContext dbContext, IAlbumService albumService, ISongService songService)
            : base(dbContext)
        {
            this.albumService = albumService;
            this.songService = songService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.ViewBag.Albums = this.albumService.GetAllAsSelectListItem();

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateSongBM createSongBM)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(createSongBM);
            }

            songService.Create(createSongBM);

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
