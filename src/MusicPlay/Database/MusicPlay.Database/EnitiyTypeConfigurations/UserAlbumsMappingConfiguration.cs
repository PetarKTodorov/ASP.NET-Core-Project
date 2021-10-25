namespace MusicPlay.Database.EnitiyTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MisicPlay.Models;

    internal class UserAlbumsMappingConfiguration : IEntityTypeConfiguration<UserAlbumsMapping>
    {
        public void Configure(EntityTypeBuilder<UserAlbumsMapping> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasAlternateKey(uam => new { uam.UserId, uam.AlbumId });

            builder.HasOne(uam => uam.User)
                .WithMany(u => u.UserAlbumsMapping)
                .HasForeignKey(uam => uam.UserId);

            builder.HasOne(uam => uam.Album)
                .WithMany(a => a.UserAlbumsMapping)
                .HasForeignKey(uam => uam.AlbumId);
        }
    }
}
