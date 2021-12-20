namespace MusicPlay.Services.Album
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using MisicPlay.Models;

    public interface IAlbumService
    {
        public IEnumerable<Album> GetAll();

        public IEnumerable<SelectListItem> GetAllAsSelectListItem();
    }
}
