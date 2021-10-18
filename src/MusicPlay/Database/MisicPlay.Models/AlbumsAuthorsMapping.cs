namespace MisicPlay.Models
{
    using System;

    public class AlbumsAuthorsMapping : BaseEntity
    {
        public Guid AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
