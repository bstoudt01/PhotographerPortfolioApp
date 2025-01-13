using System.ComponentModel.DataAnnotations;

namespace AStoudtPhotographyAPI.DTO
{
    public class AddPhotoRequest
    {
        [Required]
        public int SessionId { get; set; }

        [Required]
        public int GalleryId { get; set; }
        
        [Required]
        public bool IsPrivate { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public List<IFormFile>? Photos { get; set; }
    }
}
