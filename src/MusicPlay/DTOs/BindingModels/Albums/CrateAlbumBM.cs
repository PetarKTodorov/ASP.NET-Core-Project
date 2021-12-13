namespace MusicPlay.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CrateAlbumBM
    {
        [MinLength(2)]
        [Required]
        public string Name { get; set; }

        public DateTime RelaseDate { get; set; }

        public Guid[] authors { get; set; }
    }
}
