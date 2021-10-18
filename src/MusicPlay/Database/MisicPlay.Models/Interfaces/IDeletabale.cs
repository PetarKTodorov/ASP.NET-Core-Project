namespace MisicPlay.Models.Interfaces
{
    using System;

    public interface IDeletabale
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
