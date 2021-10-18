namespace MisicPlay.Models
{
    using System;

    public class UserAlbumsMapping : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
