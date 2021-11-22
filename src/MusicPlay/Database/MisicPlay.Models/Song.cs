namespace MisicPlay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;

    using MisicPlay.Models.Interfaces;

    public class Song : BaseEntity, IDeletabale, IModified
    {
        public Song()
        {
            this.UserSongsMapping = new HashSet<UserSongsMapping>();
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public DateTime RelaseDate { get; set; }

        public Guid? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual IEnumerable<UserSongsMapping> UserSongsMapping { get; set; }
    }
}
