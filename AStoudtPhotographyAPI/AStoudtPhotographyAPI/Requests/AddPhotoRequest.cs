using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AStoudtPhotographyAPI.DTO
{
    public class AddPhotoRequest
    {
        public int SessionId { get; set; }

        [Required]
        [FromForm]
        public int GalleryId { get; set; }
        
        [Required]
        [FromForm]
        public bool IsPrivate { get; set; }

        [Required]
        [FromForm]
        public int ClientId { get; set; }

        [Required]
        [FromForm]
        public List<IFormFile>? Photos { get; set; }

    }
}
