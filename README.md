# ASP.NET-Core-Project

## Dabase
### Models: 

Authors
- GUID ID
- string Names
- DateTime Birthday
- IEnumerable<Album> Albums
- bool IsAlive
- IEnumerable<Award> Awards
- DateTime CreatedOn
- DateTime? DeletedOn
- DateTime? UpdatedOn

Albums
- GUID ID
- string Name
- DateTime RelaseDate
- IEnumerable<Author> Authors
- IEnumerable<Song> Songs
- DateTime CreatedOn
- DateTime? DeletedOn
- DateTime? UpdatedOn
- IEnumerable<UserAlbumsMapping> FavourireAlbums

AlbumsAuthorsMapping
- GUID ID

- GUID AlbumId
- GUID AuthorId 

Awards
- GUID ID
- DateTime CreatedOn
- DateTime? DeletedOn
- DateTime? UpdatedOn
- string Name - unique
- GUID AuthorId
- Author Author

Songs
- GUID ID
- DateTime CreatedOn
- DateTime? DeletedOn
- DateTime? UpdatedOn
- GUID AlbumId
- DateTime RelaseDate
- string Name
- IEnumerable<UserSongsMapping> FavourireSongs

UserSongsMapping
- GUID ID

- GUID UserId
- GUID SongId 

UserAlbumsMapping
- GUID ID

- GUID UserId
- GUID AlbumId 


Users
- IEnumerable<UserSongsMapping> FavourireSongs
- IEnumerable<UserAlbumsMapping> FavourireAlbums

