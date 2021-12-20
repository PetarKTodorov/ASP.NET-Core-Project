using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlay.BindingModels
{
    public class CreateSongBM
    {
        public string Name { get; set; }

        public DateTime RelaseDate { get; set; }

        public Guid? AlbumId { get; set; }
    }
}
