namespace AStoudtPhotographyAPI.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public int PhotoSession {  get; set; }

        public bool IsPrivate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int ClientId { get; set; }

        public int GalleryId { get; set; }

    }
}
