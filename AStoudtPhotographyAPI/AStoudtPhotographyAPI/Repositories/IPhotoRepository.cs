using AStoudtPhotographyAPI.Models;

namespace AStoudtPhotographyAPI.Repositories
{
    public interface IPhotoRepository
    {
        Task Add(Photo photo);
    }
}
