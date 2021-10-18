namespace MisicPlay.Models.Interfaces
{
    using System;

    public interface IModified
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
