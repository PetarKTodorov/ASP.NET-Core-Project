namespace MusicPlay.WebApplication.Areas.Admin.Controllers
{
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

    public class AlbumController : BaseAdminController
    {
        public AlbumController(MusicPlayDbContext dbContext) 
            : base(dbContext)
        {

        }

        [HttpGet]
        public IActionResult Create()
        {
            var allAuthors = this.DbContext.Authors
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Names,
                })
                .ToArray();

            this.ViewBag.AllAuthors = allAuthors;

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CrateAlbumBM crateAlbumBM)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(crateAlbumBM);
            }

            var album = new Album();
            album.Name = crateAlbumBM.Name;
            album.RelaseDate = crateAlbumBM.RelaseDate;
            album.CreatedOn = DateTime.UtcNow;

            this.DbContext.Albums.Add(album);

            foreach (var author in crateAlbumBM.authors)
            {
                var albumsAuthorsMapping = new AlbumsAuthorsMapping();
                albumsAuthorsMapping.AuthorId = author;
                albumsAuthorsMapping.AlbumId = album.Id;

                this.DbContext.AlbumsAuthorsMapping.Add(albumsAuthorsMapping);
            }

            this.DbContext.SaveChanges();

            return RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var album = this.DbContext.Albums.SingleOrDefault(s => s.Id == id);

            if (album == null)
            {
                return RedirectToAction(nameof(this.Create));
            }

            return this.View(album);
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(album);
            }

            album.UpdatedOn = DateTime.UtcNow;

            this.DbContext.Albums.Update(album);

            this.DbContext.SaveChanges();

            return RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var album = this.DbContext.Albums.SingleOrDefault(s => s.Id == id);

            if (album.IsDeleted == true)
            {
                return RedirectToAction(nameof(this.All));
            }

            if (album == null)
            {
                return RedirectToAction(nameof(this.Create));
            }

            return this.View(album);
        }

        [HttpPost]
        public IActionResult Delete(Album album)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(album);
            }

            if (album.IsDeleted)
            {
                return RedirectToAction(nameof(this.All));
            }

            album.UpdatedOn = DateTime.UtcNow;
            album.IsDeleted = true;
            album.DeletedOn = DateTime.UtcNow;

            this.DbContext.Albums.Update(album);

            var allAlbumSongs = this.DbContext.Songs
                .Where(s => s.AlbumId == album.Id);

            foreach (var song in allAlbumSongs)
            {
                song.IsDeleted = true;
            }

            this.DbContext.Songs.UpdateRange(allAlbumSongs);

            this.DbContext.SaveChanges();

            return RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult All()
        {
            var albums = this.DbContext.Albums
                .Include(a => a.Songs)
                .Include(a => a.AlbumsAuthorsMapping)
                .ThenInclude(a => a.Author)
                .ToArray();

            return this.View(albums);
        }


    }
}
