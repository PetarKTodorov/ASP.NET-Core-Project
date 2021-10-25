namespace MusicPlay.Database.EnitiyTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MisicPlay.Models;

    internal class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasIndex(a => a.Name)
               .IsUnique();

            builder.HasOne(a => a.Author)
                .WithMany(a => a.Awards)
                .HasForeignKey(a => a.AuthorId);
        }
    }
}
