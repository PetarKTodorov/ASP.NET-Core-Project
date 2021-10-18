namespace MisicPlay.Models
{
    using System;

    public class UserSongsMapping : BaseEntity
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Guid SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
