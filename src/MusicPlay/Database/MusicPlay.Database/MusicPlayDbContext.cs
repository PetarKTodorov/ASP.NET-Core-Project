namespace MusicPlay.Database
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using MisicPlay.Models;

    public class MusicPlayDbContext : IdentityDbContext<User>
    {

        public MusicPlayDbContext(DbContextOptions<MusicPlayDbContext> options)
            : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<AlbumsAuthorsMapping> AlbumsAuthorsMapping { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAlbumsMapping> UsersAlbumsMapping { get; set; }

        public DbSet<UserSongsMapping> UsersSongsMapping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
