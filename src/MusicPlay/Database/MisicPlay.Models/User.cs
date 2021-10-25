
namespace MisicPlay.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.UserSongsMapping = new HashSet<UserSongsMapping>();
            this.UserAlbumsMapping = new HashSet<UserAlbumsMapping>();
        }

        public IEnumerable<UserSongsMapping> UserSongsMapping { get; set; }

        public IEnumerable<UserAlbumsMapping> UserAlbumsMapping { get; set; }

    }
}
