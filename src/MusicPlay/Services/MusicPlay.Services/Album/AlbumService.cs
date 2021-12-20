namespace MusicPlay.Services.Album
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using MisicPlay.Models;

    using MusicPlay.Database;

    public class AlbumService : BaseService, IAlbumService
    {
        public AlbumService(MusicPlayDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<Album> GetAll()
        {
            var allAlbums = this.DbContext.Albums
                .Where(a => a.IsDeleted == false)
                .ToArray();

            return allAlbums;
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItem()
        {
            var allAlbums = this.GetAll()
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name,
                })
                .ToArray();

            return allAlbums;
        }
    }
}
