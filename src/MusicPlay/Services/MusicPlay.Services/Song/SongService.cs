namespace MusicPlay.Services.Song
{
    using MusicPlay.Database;
    using MisicPlay.Models;
    using System;
    using MusicPlay.BindingModels;

    public class SongService : BaseService, ISongService
    {
        public SongService(MusicPlayDbContext dbContext)
            : base(dbContext)
        {
        }

        public Song Create(CreateSongBM createSongBM)
        {
            var song = new Song();

            song.AlbumId = createSongBM.AlbumId;
            song.Name = createSongBM.Name;
            song.RelaseDate = createSongBM.RelaseDate;
            song.CreatedOn = DateTime.UtcNow;

            this.DbContext.Songs.Add(song);

            this.DbContext.SaveChanges();

            return song;
        }
    }
}
