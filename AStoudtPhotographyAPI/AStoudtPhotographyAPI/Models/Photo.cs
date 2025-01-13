namespace AStoudtPhotographyAPI.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public int SessionId {  get; set; }

        public int GalleryId { get; set; }

        public string FileLocation { get; set; } = string.Empty;

        public bool IsPrivate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int ClientId { get; set; }
    }
}
