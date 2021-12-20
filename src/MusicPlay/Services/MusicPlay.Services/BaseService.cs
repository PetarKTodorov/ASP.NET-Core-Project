namespace MusicPlay.Services
{
    using MusicPlay.Database;

    public class BaseService
    {
        public BaseService(MusicPlayDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public MusicPlayDbContext DbContext { get; set; }
    }
}
