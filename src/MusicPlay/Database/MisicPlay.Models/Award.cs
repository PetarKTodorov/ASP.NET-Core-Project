namespace MisicPlay.Models
{
    using System;

    using MisicPlay.Models.Interfaces;

    public class Award : BaseEntity, IDeletabale, IModified
    {
        public string Name { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
