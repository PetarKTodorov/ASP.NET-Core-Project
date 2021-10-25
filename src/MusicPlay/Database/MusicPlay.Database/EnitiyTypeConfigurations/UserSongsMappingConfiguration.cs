namespace MusicPlay.Database.EnitiyTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MisicPlay.Models;
    internal class UserSongsMappingConfiguration : IEntityTypeConfiguration<UserSongsMapping>
    {
        public void Configure(EntityTypeBuilder<UserSongsMapping> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasAlternateKey(usm => new { usm.UserId, usm.SongId });

            builder.HasOne(usm => usm.User)
                .WithMany(u => u.UserSongsMapping)
                .HasForeignKey(usm => usm.UserId);

            builder.HasOne(usm => usm.Song)
                .WithMany(s => s.UserSongsMapping)
                .HasForeignKey(usm => usm.SongId);
        }
    }
}
