namespace AStoudtPhotographyAPI.DTO
{
    public class AddPhotoRequest
    {
        public int SessionId { get; set; }

        public int GalleryId { get; set; }

        public bool IsPrivate { get; set; }

        public int ClientId { get; set; }

        public required List<IFormFile> Photos { get; set; }
    }
}
