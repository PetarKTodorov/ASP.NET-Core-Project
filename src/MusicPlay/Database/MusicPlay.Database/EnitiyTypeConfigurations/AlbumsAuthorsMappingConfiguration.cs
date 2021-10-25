namespace MusicPlay.Database.EnitiyTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MisicPlay.Models;

    internal class AlbumsAuthorsMappingConfiguration : IEntityTypeConfiguration<AlbumsAuthorsMapping>
    {
        public void Configure(EntityTypeBuilder<AlbumsAuthorsMapping> builder)
        {
            builder.HasKey(aam => aam.Id);

            builder.HasAlternateKey(aam => new { aam.AlbumId, aam.AuthorId });

            builder.HasOne(aam => aam.Album)
                .WithMany(a => a.AlbumsAuthorsMapping)
                .HasForeignKey(aam => aam.AlbumId);

            builder.HasOne(aam => aam.Author)
                .WithMany(a => a.AlbumsAuthorsMapping)
                .HasForeignKey(aam => aam.AuthorId);
        }
    }
}
