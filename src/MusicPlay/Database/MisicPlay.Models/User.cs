
namespace MisicPlay.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.FavourireAlbums = new HashSet<UserAlbumsMapping>();
            this.FavourireSongs = new HashSet<UserSongsMapping>();
        }

        public IEnumerable<UserSongsMapping> FavourireSongs { get; set; }

        public IEnumerable<UserAlbumsMapping> FavourireAlbums { get; set; }

    }
}
