namespace MusicPlay.Services.Song
{
    using MisicPlay.Models;

    using MusicPlay.BindingModels;

    public interface ISongService
    {
        public Song Create(CreateSongBM createSongBM);
    }
}
