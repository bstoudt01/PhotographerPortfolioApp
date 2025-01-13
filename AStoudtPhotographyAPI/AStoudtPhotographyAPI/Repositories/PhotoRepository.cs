using AStoudtPhotographyAPI.Models;
using AStoudtPhotographyAPI.Utilities;

namespace AStoudtPhotographyAPI.Repositories
{
    public class PhotoRepository : BaseRepository, IPhotoRepository
    {
        public PhotoRepository(IConfiguration config) : base(config) { }

        //GET All Photos By Gallery that returns the gallery model

        //GET Single/All Photos ( array of? int/string? ID, GalleryId, ClientId, PhotographerId) 

        //POST New Photo Uploads
        public async Task Add(Photo photo)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO dbo.Photo (SessionID, ClientID, GalleryID, FileLocation, IsPrivate, CreatedDateTime)
                        VALUES (@SessionID, @ClientID, @GalleryID, @FileLocation, @IsPrivate, @CreatedDateTime)";

                    //cmd.Parameters.AddWithValue("@ID", photo.Id);
                    DbUtilities.AddParameter(cmd, "@SessionID", photo.SessionId);
                    DbUtilities.AddParameter(cmd, "@ClientID", photo.ClientId);
                    DbUtilities.AddParameter(cmd, "@GalleryID", photo.GalleryId);
                    DbUtilities.AddParameter(cmd, "@FileLocation", photo.FileLocation);
                    DbUtilities.AddParameter(cmd, "@IsPrivate", photo.IsPrivate);
                    DbUtilities.AddParameter(cmd, "@CreatedDateTime", DateTime.Now);

                    await cmd.ExecuteNonQueryAsync();

                   // photo.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
