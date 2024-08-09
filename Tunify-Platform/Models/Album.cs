namespace Tunify_Platform.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
