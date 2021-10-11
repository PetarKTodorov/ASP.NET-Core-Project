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
- IEnumerable<Author> Albums
- IEnumerable<Song> Songs
- DateTime CreatedOn
- DateTime? DeletedOn
- DateTime? UpdatedOn

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

Users
- IEnumerable<Songs> FavourireSongs
- IEnumerable<Albums> FavourireAlbums

