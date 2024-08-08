namespace Tunify_Platform.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string PlaylistName { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }
    }
}
