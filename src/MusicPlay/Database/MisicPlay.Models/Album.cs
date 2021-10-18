namespace MisicPlay.Models
{
    using System;
    using System.Collections.Generic;

    using MisicPlay.Models.Interfaces;

    public class Album : BaseEntity, IDeletabale, IModified
    {
        public Album()
        {
            this.Authors = new HashSet<AlbumsAuthorsMapping>();
            this.Songs = new HashSet<Song>();
            this.FavourireUsersAlbums = new HashSet<UserAlbumsMapping>();
        }

        public string Name { get; set; }

        public DateTime RelaseDate { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual IEnumerable<AlbumsAuthorsMapping> Authors { get; set; }

        public virtual IEnumerable<Song> Songs { get; set; }

        public virtual IEnumerable<UserAlbumsMapping> FavourireUsersAlbums { get; set; }

    }
}
