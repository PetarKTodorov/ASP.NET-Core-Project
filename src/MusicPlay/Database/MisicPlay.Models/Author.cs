namespace MisicPlay.Models
{
    using System;
    using System.Collections.Generic;

    using MisicPlay.Models.Interfaces;

    public class Author : BaseEntity, IDeletabale, IModified
    {
        public Author()
        {
            this.Albums = new HashSet<AlbumsAuthorsMapping>();
            this.Awards = new HashSet<Award>();
        }

        public string Names { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsAlive { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual IEnumerable<AlbumsAuthorsMapping> Albums { get; set; }

        public virtual IEnumerable<Award> Awards { get; set; }
    }
}
